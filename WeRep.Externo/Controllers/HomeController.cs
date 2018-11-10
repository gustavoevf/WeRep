using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeRep.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Response.Cookies["log"].Value = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //Response.Cookies["log"].Expires = DateTime.Now.AddSeconds(30);

            if (Request.Cookies["log"] != null && Request.Cookies["log"].Value == System.Security.Principal.WindowsIdentity.GetCurrent().Name)
                return RedirectToAction("Index", "Usuario", new { id = 5 });
            return View();
        }
    }
}