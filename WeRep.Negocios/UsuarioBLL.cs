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
        public void Cadastro(string nome, string senha)
        {
            UsuarioDAL Usuario = new UsuarioDAL();
            Usuario.Cadastro(nome, senha);
        }
        public UsuarioModel ListarDadosPerfil(int id)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ListarDadosPerfil(id);
        }
    }
}