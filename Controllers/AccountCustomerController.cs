using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProjectClient.Controllers
{
    public class AccountCustomerController : Controller
    {

        private readonly MyDB_Context _context;

        public AccountCustomerController(MyDB_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }


        //[HttpPost] // POST khi submit form
        //public IActionResult Login(string email,string pass)
        //{
        //    //var password = GetMD5(pass);
        //    //var acc = _context.Account.FirstOrDefault(x => x.Email == email && x.Password == password);
        //    //if (acc != null)
        //    //{
        //    //    HttpContext.Session.SetString("LoginCustomer", "Demo");
        //    //    return RedirectToAction("Index", "Home");
        //    //}
        //    HttpContext.Session.SetString("LoginCustomer", "Demo");
        //    return RedirectToAction("Index");
        //}

        public IActionResult Login()
        {
            HttpContext.Session.SetString("Demo", "Lê Quang Minh");
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account account)
        {
            account.State = 1;
            account.Decentralization = false;
            var pass = GetMD5(account.Password);
            account.Password = pass;
            _context.Account.Add(account);
            _context.SaveChanges();
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



