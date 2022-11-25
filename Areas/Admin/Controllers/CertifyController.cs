using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CertifyController : Controller
    {
        private readonly MyDB_Context _context;

        public CertifyController(MyDB_Context context)
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
            var dataList = _context.Certify.OrderByDescending(x => x.CertifyType).ToList();
            return Json(new { data = dataList });
        }

        [HttpGet]
        public IActionResult getList(string certifyType, int page)
        {
            int pageSize = 5;
            int _page;
            if (page > 0) { _page = page; } else { _page = 1; }

            int start = (_page - 1) * pageSize;

            if (certifyType == null || certifyType.Length <= 0)
            {
                var list = _context.Certify.ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Certify.OrderByDescending(x => x.CertifyType).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
            else
            {
                var list = _context.Certify.Where(x => x.CertifyType.Contains(certifyType)).ToList().Count;
                double totalNumsize = (list / (double)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);

                var dataList = _context.Certify.OrderByDescending(x => x.CertifyType).Where(x => x.CertifyType.Contains(certifyType)).Skip(start).Take(pageSize).ToList();

                return Json(new { data = dataList, pageCurrent = _page, size = numSize });
            }
        }


        public async Task<IActionResult> GetCertify(Guid idCertify)
        {
            var obj = await _context.Certify.FindAsync(idCertify);
            return Json(new { data = obj });
        }


        [HttpPost]
        public ActionResult Create(Certify model)
        {
            _context.Certify.Add(model);
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

        public async Task<IActionResult> Delete(Guid idCertify)
        {
            var data = await _context.Certify.FindAsync(idCertify);
            _context.Certify.Remove(data);
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
        public ActionResult Update(Certify model, Guid idCertify)
        {
            _context.Certify.Update(model);
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