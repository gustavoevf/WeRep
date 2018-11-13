using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Negocios;
using WeRep.Models;
using System.Web.SessionState;

namespace WeRep.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            var SessionObj = (UsuarioModel)Session["user"];
            if (new UsuarioBLL().EstaLogado(SessionObj.nome, SessionObj.senha)) ;
            return View();
        }

        public ActionResult VerPerfil()
        {
            UsuarioBLL User = new UsuarioBLL();
            UsuarioViewModel DTO = new UsuarioViewModel();
            UsuarioModel dadosListados = User.ListarDadosPerfil();
            DTO.nome = dadosListados.nome;
            DTO.senha = dadosListados.senha;
            return View(DTO);
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoUsuario(UsuarioViewModel novoUsuario)
        {
            string nome = novoUsuario.nome;
            string senha = novoUsuario.senha;
            UsuarioBLL Usuario = new UsuarioBLL();
            Session["user"] = Usuario.Cadastro(nome, senha);
            return RedirectToAction("Index");
        }
    }
}