using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Negocios;
using WeRep.Models;

namespace WeRep.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerPerfil()
        {
            UsuarioBLL User = new UsuarioBLL();
            UsuarioViewModel DTO = new UsuarioViewModel();
            DTO.nome = User.ListarDadosPerfil().nome;
            DTO.senha = User.ListarDadosPerfil().senha;
            return View(DTO);
        }
    }
}