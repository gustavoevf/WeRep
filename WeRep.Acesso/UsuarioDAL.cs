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
        public UsuarioModel Cadastro(string nome, string senha)
        {
            Mock Usuario = new Mock();
            return Usuario.Cadastro(nome, senha);
        }

        public UsuarioModel ListarDadosPerfil()
        {
            Mock DB_FAKE = new Mock();
            return DB_FAKE.RetornarUsuario();
        }
    }
}