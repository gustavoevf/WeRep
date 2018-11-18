using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using WeRep.Models;
using WeRep.Models.Models;
using Acesso;

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
            return UsuarioExistente(nome);
        }

        public bool UsuarioExistente(string nome)
        {
            UsuarioDAL Validacao = new UsuarioDAL();
            return Validacao.UsuarioExistente(nome);
        }

        public bool UsuarioExistente(int id)
        {
            UsuarioDAL Validacao = new UsuarioDAL();
            return Validacao.UsuarioExistente(id);
        }

        public UsuarioModel ListarDadosPerfil(int id)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(id);
        }

        public UsuarioModel ListarDadosPerfil(string nome)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(nome);
        }

        public UsuarioViewModelDTO RelacaoUsuario(int id)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.RelacaoUsuario(id);
        }

        public void AlterarTipo(int id, int tipo)
        {
            new UsuarioDAL().AlterarTipoUsuario(tipo, id);
        }
    }
}