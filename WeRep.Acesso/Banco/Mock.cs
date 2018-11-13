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
        // Caminho dos arquivos de texto 
        string path_republicas = "\\txt\\republicas.txt";
        string path_usuario = "\\txt\\usuarios.txt";

        // Lê o texto, armazena em uma lista, define o id da nova republica (ordem crescente a partir do 1) e adiciona na lista e, 
        // por fim, escreve o texto com a republica adicionada 
         
        public void InserirRepublica(RepublicaModel republica_dados)
        {
            string readText = File.ReadAllText(path_republicas);
            List<RepublicaModel> lista;
            lista = new JavaScriptSerializer().Deserialize<List<RepublicaModel>>(readText);

            List<RepublicaModel> listaOrdenada = new List<RepublicaModel>();
            RepublicaModel nova_republica = new RepublicaModel
            { nome = republica_dados.nome,
              id_adm = republica_dados.id_adm,
              rua = republica_dados.rua,
              numero = republica_dados.numero,
              complemento = republica_dados.complemento,
              capacidade = republica_dados.capacidade,
              moradores = republica_dados.moradores,
              cidade = republica_dados.cidade,
              estado = republica_dados.estado
            };

            if (listaOrdenada.Count > 0)
            {
                listaOrdenada = lista.OrderBy(x => x.id_rep).ToList();
                nova_republica.id_rep = listaOrdenada.Last().id_rep + 1;
            }
            else
                nova_republica.id_rep = 1;
            listaOrdenada.Add(nova_republica);
            string json = new JavaScriptSerializer().Serialize(listaOrdenada);
            File.WriteAllText(path_republicas, json);
        }


        // Lê o texto, armazena em uma lista, define o id do novo usuário (ordem crescente a partir do 1) e adiciona na lista e, 
        // por fim, escreve o texto com o usuário adicionado
        public void Cadastro(string nome, string senha)
        {
            string readText = File.ReadAllText(path_usuario);
            List<UsuarioModel> lista;
            lista = new JavaScriptSerializer().Deserialize<List<UsuarioModel>>(readText);

            List<UsuarioModel> listaOrdernada = new List<UsuarioModel>();
            UsuarioModel novo_usuario = new UsuarioModel { nome = nome, senha = senha, tipo = 1 };
            if (listaOrdernada.Count > 0)
            {
                listaOrdernada = lista.OrderBy(x => x.id_user).ToList();
                novo_usuario.id_user = listaOrdernada.Last().id_user + 1;
            }
            else
                novo_usuario.id_user = 1;
            listaOrdernada.Add(novo_usuario);
            string json = new JavaScriptSerializer().Serialize(listaOrdernada);
            File.WriteAllText(path_usuario, json);
        }

        public UsuarioModel RetornarUsuario(int idt)
        {
            string readText = File.ReadAllText("usuarios.txt");
            return new UsuarioModel();
        }
        
    }
}