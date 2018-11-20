using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Negocios;
using WeRep.Models;

namespace WeRep.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var SessionObj = (UsuarioModel)Session["user"];

            if (SessionObj != null && new UsuarioBLL().EstaLogado(SessionObj.nome, SessionObj.senha))
                return RedirectToAction("Index", "Usuario");
            return View();
        }

        public ViewResult Falha()
        {
            return View();
        }
    }
}