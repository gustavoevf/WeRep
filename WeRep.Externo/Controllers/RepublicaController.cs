using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Models;
using WeRep.Negocios;

namespace WeRep.Controllers
{
    public class RepublicaController : Controller
    {
        public ActionResult Index()
        {
            var session_user = (UsuarioModel)Session["user"];
            Session["republica"] = new RepublicaBLL().RetornarRepublica(session_user.id_rep.Value);
            return View((RepublicaModel)Session["republica"]);
        }

        public ActionResult CriarRepublica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarRepublica(RepublicaModel nova_rep)
        {
            var session_user = (UsuarioModel)Session["user"];
            nova_rep.id_adm = session_user.id_user.Value;

            new RepublicaBLL().CadastrarRepublica(nova_rep);
            return RedirectToAction("Index", "Usuario");
        }

        public void InserirMorador(List<string> moradores, int id_rep)
        {
            new RepublicaBLL().InserirMorador(moradores, id_rep);
        }
    }
}
