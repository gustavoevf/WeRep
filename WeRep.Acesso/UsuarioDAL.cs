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
        public UsuarioModel ListarDadosPerfil(int id)
        {
            Mock DB_FAKE = new Mock();
            return DB_FAKE.RetornarUsuario(id);
        }
    }
}