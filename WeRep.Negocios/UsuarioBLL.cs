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
        public void Cadastro(string nome, string senha)
        {
            UsuarioDAL Usuario = new UsuarioDAL();
            Usuario.Cadastro(nome, senha);
        }

        public bool EstaLogado(string nome, string senha)
        {
            if (nome == null || nome == "" || senha == null || senha == "")
                return false;
            return UsuarioExistente(nome, senha);
        }

        public bool UsuarioExistente(string nome, string senha)
        {
            UsuarioDAL Validacao = new UsuarioDAL();
            return Validacao.UsuarioExistente(nome, senha);
        }

        public UsuarioModel ListarDadosPerfil(int id)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(id);
        }

        public UsuarioModel ListarDadosPerfil(string nome, string senha)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(nome, senha);
        }
    }
}