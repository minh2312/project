using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GoldkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly MyDB_Context _context;

        [HttpGet]
        public IActionResult GetAllList()
        {
            var dataList = _context.Goldk.OrderByDescending(x => x.GoldRate).ToList();
            return Json(new { data = dataList });
        }

        public GoldkController(MyDB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getList(string goldCrt, int page)
        {
            int pageSize = 5;
            int _page;
            if (page > 0) { _page = page; } else { _page = 1; }

            int start = (_page - 1) * pageSize;

            if (goldCrt == null || goldCrt.Length <= 0)
            {
                var list = _context.Goldk.ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Goldk.OrderByDescending(x => x.GoldRate).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
            else
            {
                var list = _context.Goldk.Where(x => x.Gold_Crt.Contains(goldCrt)).ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Goldk.OrderByDescending(x => x.GoldRate).Where(x => x.Gold_Crt.Contains(goldCrt)).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
        }


        public async Task<IActionResult> GetGuld(Guid goldTypeId)
        {
            var data = await _context.Goldk.FindAsync(goldTypeId);
            return Json(new { data = data });
        }


        [HttpPost]
        public ActionResult Create(Goldk model)
        {
            _context.Goldk.Add(model);
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

        public async Task<IActionResult> Delete(Guid goldTypeId)
        {
            var data = await _context.Goldk.FindAsync(goldTypeId);
            _context.Goldk.Remove(data);
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
        public ActionResult UpdateGuldk(Goldk model, Guid goldTypeId)
        {
            _context.Goldk.Update(model);
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