using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace eProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly MyDB_Context _context;

        public AccountController(MyDB_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, int role)
        {
            //if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            //{
            //    return RedirectToAction("Index");
            //}

            var pass = GetMD5(password);
            var acc = _context.Account.FirstOrDefault(x => x.Email == email && x.Password == pass && x.Decentralization == true);
            if (acc != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, acc.Email),
                    new Claim(ClaimTypes.Name, acc.FullName)
                }, "EProject");
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync("EProject", principal);
                return Redirect("/Admin/Category");
            }
            return RedirectToAction("Index");
        }


        public static string GetMD5(String str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}