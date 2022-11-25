using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace eProjectClient.Controllers
{
    public class BaseController : Controller,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admin" })
                );
            }
            base.OnActionExecuting(context);
        }
    }
}