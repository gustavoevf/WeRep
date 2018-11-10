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
        // GET: Usuario
        public ActionResult Index(int id)

        {
            return View();
        }

        public ActionResult VerPerfil(int id_SESSION)
        {
            UsuarioBLL User = new UsuarioBLL();
            UsuarioViewModel DTO = new UsuarioViewModel();
            DTO.nome = User.ListarDadosPerfil(id_SESSION).nome;
            DTO.senha = User.ListarDadosPerfil(id_SESSION).senha;
            return View(DTO);
        }
    }
}