using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Acesso.Banco
{
    public class Mock
    {
        string path_usuario = "\\txt\\usuarios.txt";
        public void InserirRepublica(RepublicaModel republica_dados)
        {
        }

        public UsuarioModel Cadastro(string nome, string senha)
        {
            string readText = File.ReadAllText(path_usuario);
            List<UsuarioModel> lista;
            lista = new JavaScriptSerializer().Deserialize<List<UsuarioModel>>(readText);

            List<UsuarioModel> listaOrdernada = new List<UsuarioModel>();
            if (listaOrdernada.Count > 0) { listaOrdernada = lista.OrderBy(x => x.id_user).ToList(); }
            UsuarioModel novo_usuario = new UsuarioModel{ nome = nome, senha = senha, tipo = 1 };
            if (listaOrdernada.Count > 0)
                novo_usuario.id_user = listaOrdernada[listaOrdernada.Count - 1].id_user + 1;
            else
                novo_usuario.id_user = 1;
            listaOrdernada.Add(novo_usuario);
            string json = new JavaScriptSerializer().Serialize(listaOrdernada);
            File.WriteAllText(path_usuario, json);
            return novo_usuario;
        }

        public UsuarioModel RetornarUsuario()
        {
            string readText = File.ReadAllText(path_usuario);
            List<UsuarioModel> lista;
            lista = new JavaScriptSerializer().Deserialize<List<UsuarioModel>>(readText);

            return lista[0];
        } 
    }
}