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
            if (SessionObj != null && new UsuarioBLL().EstaLogado(SessionObj.nome, SessionObj.senha))
                return View();
            else
            {
                Session["user"] = null;
                return RedirectToAction("Falha", "Home");
            }
        }

        public ActionResult VerPerfil()
        {
            var SessionObj = (UsuarioModel)Session["user"];
            UsuarioBLL User = new UsuarioBLL();
            UsuarioViewModel DTO = new UsuarioViewModel();
            UsuarioModel dadosListados = User.ListarDadosPerfil(SessionObj.id_user.Value);
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
            Usuario.Cadastro(nome, senha);

            #region popula session
            Session["user"] = Usuario.ListarDadosPerfil(nome, senha);
            #endregion

            return RedirectToAction("Index");
        }
    }
}