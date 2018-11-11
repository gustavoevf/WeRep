using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using System.Web.Script.Serialization;
using System.IO;

namespace Acesso.Banco
{
    public class Mock
    {
        string path_usuario = "\\txt\\usuarios.txt";
        public void InserirRepublica(RepublicaModel republica_dados)
        {
        }

        public void Cadastro(string nome, string senha)
        {
            string readText = File.ReadAllText(path_usuario);
            List<UsuarioModel> lista_usuarios;
            lista_usuarios = new JavaScriptSerializer().Deserialize<List<UsuarioModel>>(readText);
            UsuarioModel novo_usuario = new UsuarioModel{ nome = nome, senha = senha, tipo = 1 };
            lista_usuarios.Add(novo_usuario);
            string json = new JavaScriptSerializer().Serialize(lista_usuarios);
            File.WriteAllText(path_usuario, json);
        }

        public UsuarioModel RetornarUsuario(int idt)
        {
            string readText = File.ReadAllText("usuarios.txt");
            return new UsuarioModel();
        } 
    }
}