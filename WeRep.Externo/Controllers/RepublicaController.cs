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
            var session_rep = (RepublicaModel)Session["republica"];

            RepublicaViewModel viewModel = new RepublicaViewModel();
            viewModel.moradores = new List<string>();

            if (session_rep != null)
            {

                viewModel.adm = new UsuarioBLL().ListarDadosPerfil(session_rep.id_adm).nome;
                viewModel.bairro = session_rep.bairro;
                viewModel.capacidade = session_rep.capacidade;
                viewModel.cidade = session_rep.cidade;
                viewModel.complemento = session_rep.complemento;
                viewModel.estado = session_rep.estado;
                viewModel.nome = session_rep.nome;
                viewModel.numero = session_rep.numero;
                viewModel.rua = session_rep.rua;
                foreach (int morador in session_rep.moradores)
                    viewModel.moradores.Add(new UsuarioBLL().ListarDadosPerfil(morador).nome);
            }

            return View(viewModel);
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
