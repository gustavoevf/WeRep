using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using Acesso.Banco;

namespace Acesso
{
    public class UsuarioDAL
    {
        public void Cadastro(string nome, string senha)
        {
            Mock Usuario = new Mock();
            Usuario.Cadastro(nome, senha);
        }

        public UsuarioModel ListarDadosPerfil(int id)
        {
            Mock DB_FAKE = new Mock();
            return DB_FAKE.RetornarUsuario(id);
        }

        public UsuarioModel ListarDadosPerfil(string nome, string senha)
        {
            Mock DB_FAKE = new Mock();
            return DB_FAKE.RetornarUsuario(nome, senha);
        }

        public bool UsuarioExistente(string nome, string senha)
        {
            Mock DB_FAKE = new Mock();
            if (DB_FAKE.RetornarUsuario(nome, senha) != null)
                return true;
            return false;
        }
    }
}