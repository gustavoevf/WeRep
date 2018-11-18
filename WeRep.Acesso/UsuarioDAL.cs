using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using WeRep.Models.Models;
using System.IO;
using System.Web.Script.Serialization;

namespace Acesso
{
    public class UsuarioDAL : Utilidades
    {
        public void Cadastro(string nome, string senha)
        {
            List<UsuarioModel> lista = lerUsuarios();

            UsuarioModel novo_usuario = new UsuarioModel { nome = nome, senha = senha, tipo = 1 };
            if (lista.Count > 0)
                novo_usuario.id_user = lista.Last().id_user + 1;
            else
                novo_usuario.id_user = 1;
            lista.Add(novo_usuario);
            Reescrever(typeof(UsuarioModel), new JavaScriptSerializer().Serialize(lista));
        }

        public void AlterarTipoUsuario(int tipo, int id)
        {
            List<UsuarioModel> lista = lerUsuarios();
            lista.First(x => x.id_user == id).tipo = tipo;
            Reescrever(typeof(UsuarioModel), new JavaScriptSerializer().Serialize(lista));
        }

        public List<UsuarioModel> RetornarUsuario(int id)
        {
            List<UsuarioModel> lista = lerUsuarios();
            if (lista.Count <= 0)
                return new List<UsuarioModel>();

            return lista.Where(x => x.id_user == id).ToList();
        }

        public List<UsuarioModel> RetornarUsuario(string nome)
        {
            List<UsuarioModel> lista = lerUsuarios();
            if (lista.Count <= 0)
                return new List<UsuarioModel>();

            return lista.Where(x => x.nome == nome).ToList();
        }

        public string RepublicaUsuario(int id)
        {
            var lista_usuario = lerUsuarios();

            UsuarioModel usuario = lista_usuario.FirstOrDefault(x => x.id_user == id);

            var lista_republica = lerRepublicas();

            if (lista_republica.Count <= 0)
                return "";
            return lista_republica.FirstOrDefault(x => x.id_rep == usuario.id_rep).nome;
        }

        public int TipoUsuario(int id)
        {
            var lista = lerUsuarios();
            return lista.FirstOrDefault(x => x.id_user == id).tipo;
        }

        public UsuarioModel ListarDadosPerfil(int id)
        {
            if (RetornarUsuario(id).Count <= 0)
                return new UsuarioModel();
            return RetornarUsuario(id).First();
        }

        public UsuarioModel ListarDadosPerfil(string nome)
        {
            if (RetornarUsuario(nome).Count <= 0)
                return new UsuarioModel();
            return RetornarUsuario(nome).First();
        }

        public bool UsuarioExistente(int id)
        {
            if (RetornarUsuario(id).Count > 0)
                return true;
            return false;
        }

        public bool UsuarioExistente(string nome)
        {
            if (RetornarUsuario(nome).Count > 0)
                return true;
            return false;
        }

        public UsuarioViewModelDTO RelacaoUsuario(int id)
        {
            UsuarioViewModelDTO usuario = new UsuarioViewModelDTO();
            usuario.republica = RepublicaUsuario(id);
            usuario.tipo = Enum.GetName(typeof(Recursos.tipoUsuario), TipoUsuario(id));

            return usuario;
        }
    }
}