using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly MyDB_Context _context;

        public ProductController(MyDB_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getList(int page, string productName)
        {
            int pageSize = 5;
            int _page;
            if (page > 0) { _page = page; } else { _page = 1; }

            int start = (_page - 1) * pageSize;

            if (productName == null || productName.Length <= 0)
            {
                var list = _context.ItemProduct.ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.ItemProduct.Include(a=>a.Category).OrderByDescending(x => x.ProductName).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
            else
            {
                var list = _context.ItemProduct.Where(x => x.ProductName.Contains(productName)).ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.ItemProduct.OrderByDescending(x => x.ProductName).Where(x => x.ProductName.Contains(productName)).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
        }


        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var pro = await _context.ItemProduct.FindAsync(productId);
            return Json(new { data = pro });
        }


        [HttpPost]
        public ActionResult Create(ItemProduct model)
        {
            DateTime aDateTime = DateTime.Now;
            _context.ItemProduct.Add(model);
            model.CreartTime = aDateTime;
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

        public async Task<IActionResult> Delete(Guid productId)
        {
            var data = await _context.ItemProduct.FindAsync(productId);
            _context.ItemProduct.Remove(data);
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
        public ActionResult UpdateCategory(ItemProduct model, Guid productId)
        {
            _context.ItemProduct.Update(model);
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