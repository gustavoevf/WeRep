using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using WeRep.Models;
using Acesso;
using System.Web.SessionState;

namespace WeRep.Negocios
{
    public class UsuarioBLL
    {
        public UsuarioModel Cadastro(string nome, string senha)
        {
            UsuarioDAL Usuario = new UsuarioDAL();
            return Usuario.Cadastro(nome, senha);
        }

        public bool EstaLogado(string nome, string senha)
        {
            return true;
        }

        public UsuarioModel ListarDadosPerfil()
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil();
        }
    }
}