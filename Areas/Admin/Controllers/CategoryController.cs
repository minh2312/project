using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class CategoryController : Controller
    {
        private readonly MyDB_Context _context;

        public CategoryController(MyDB_Context context)
        {
            _context = context;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllList()
        {
            var dataList = _context.Category.OrderByDescending(x => x.CategoryName).ToList();
            return Json(new { data = dataList});
        }

        [HttpGet]
        public IActionResult getList(string categoryName, int page, bool status)
        {
            int pageSize = 5;
            int _page;
            if (page > 0) { _page = page; } else { _page = 1; }

            int start = (_page - 1) * pageSize;

            if (categoryName == null || categoryName.Length <= 0)
            {
                var list = _context.Category.ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Category.OrderByDescending(x => x.CategoryName).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
            else
            {
                var list = _context.Category.Where(x => x.CategoryName.Contains(categoryName)).ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Category.OrderByDescending(x => x.CategoryName).Where(x => x.CategoryName.Contains(categoryName) && x.Status == status).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize});
            }
        }


        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            return Json(new { data = category});
        }


        [HttpPost]
        public ActionResult Create(Category model)
        {
            _context.Category.Add(model);
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

        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            _context.Category.Remove(category);
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
        public ActionResult UpdateCategory(Category model, Guid categoryId)
        {
            _context.Category.Update(model);
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