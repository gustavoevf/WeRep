using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using Acesso;

namespace WeRep.Negocios
{
    public class UsuarioBLL
    {
        public UsuarioModel ListarDadosPerfil(int id)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(id);
        }
    }
}