using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly MyDB_Context _context;

        public BrandController(MyDB_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllList()
        {
            var dataList = _context.Brand.OrderByDescending(x => x.BrandName).ToList();
            return Json(new { data = dataList });
        }

        [HttpGet]
        public IActionResult getList(string brandName, int page, bool status)
        {
            int pageSize = 5;
            int _page;
            if (page > 0) { _page = page; } else { _page = 1; }

            int start = (_page - 1) * pageSize;

            if (brandName == null || brandName.Length <= 0)
            {
                var list = _context.Brand.ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Brand.OrderByDescending(x => x.BrandName).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
            else
            {
                var list = _context.Brand.Where(x => x.BrandName.Contains(brandName)).ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Brand.OrderByDescending(x => x.BrandName).Where(x => x.BrandName.Contains(brandName) && x.Status == status).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
        }


        public async Task<IActionResult> GetBrand(Guid idBrand)
        {
            var category = await _context.Brand.FindAsync(idBrand);
            return Json(new { data = category });
        }


        [HttpPost]
        public ActionResult Create(Brand model)
        {
            _context.Brand.Add(model);
            try
            {
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { err = false });
            }

        }

        public async Task<IActionResult> Delete(Guid idBrand)
        {
            var brand = await _context.Brand.FindAsync(idBrand);
            _context.Brand.Remove(brand);
            int rs = await _context.SaveChangesAsync();
            if (rs > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { err = false });
            }

        }


        [HttpPut]
        public ActionResult UpdateBrand(Brand model, Guid idBrand)
        {
            _context.Brand.Update(model);
            try
            {
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { err = false });
            }

        }
    }
}