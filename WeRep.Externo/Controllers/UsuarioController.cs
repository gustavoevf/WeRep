using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Negocios;
using WeRep.Models;
using WeRep.Models.Models;
using System.Web.SessionState;

namespace WeRep.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            var SessionObj = (UsuarioModel)Session["user"];

            if (SessionObj == null)
                return RedirectToAction("Falha", "Home");

            UsuarioViewModel ViewModel = new UsuarioViewModel();
            UsuarioViewModelDTO ViewModelDTO = new UsuarioViewModelDTO();

            UsuarioBLL usuarioUtilidades = new UsuarioBLL();
            ViewModelDTO = usuarioUtilidades.RelacaoUsuario(SessionObj.id_user.Value);

            ViewModel.nome = SessionObj.nome;
            ViewModel.republica = ViewModelDTO.republica;
            ViewModel.tipo = ViewModelDTO.tipo;

            if (new UsuarioBLL().EstaLogado(SessionObj.nome, SessionObj.senha))
                return View(ViewModel);
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

            DTO.nome = User.ListarDadosPerfil(SessionObj.id_user.Value).nome;
            DTO.republica = User.RelacaoUsuario(SessionObj.id_user.Value).republica;
            DTO.tipo = User.RelacaoUsuario(SessionObj.id_user.Value).tipo;

            return View(DTO);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario)
        {
            List<Recursos.erroListagem> lista_erros = new List<Recursos.erroListagem>();

            if (new UsuarioBLL().UsuarioExistente(usuario.nome))
            {
                if (!(new UsuarioBLL().ValidarLogin(usuario.nome, usuario.senha)))
                    lista_erros.Add(Recursos.erroListagem.SenhaErrada);
            }
            else
                lista_erros.Add(Recursos.erroListagem.UsuarioInexistente);

            if (lista_erros.Count > 0)
            {
                ViewBag.ErroLogin = lista_erros;
                return RedirectToAction("Login");
            }

            #region popula session
            Session["user"] = new UsuarioBLL().ListarDadosPerfil(usuario.nome);
            #endregion

            return RedirectToAction("Index");
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoUsuario(UsuarioModel novoUsuario)
        {
            if (new UsuarioBLL().UsuarioExistente(novoUsuario.nome))
            {
                ViewBag.ErroUsuario = Recursos.erroListagem.UsuarioJaExistente;
                return View();
            }
            string nome = novoUsuario.nome;
            string senha = novoUsuario.senha;
            new UsuarioBLL().Cadastro(nome, senha);

            #region popula session
            Session["user"] = new UsuarioBLL().ListarDadosPerfil(nome);
            #endregion

            return RedirectToAction("Index");
        }
    }
}