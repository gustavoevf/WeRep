using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WeRep.Models;
using System.Web.Script.Serialization;

namespace Acesso
{
    public class Utilidades
    {
        #region AccessOperations
        const string path_usuario = "\\txt\\usuarios.txt";
        const string path_republica = "\\txt\\republicas.txt";
        const string path_kanban = "\\txt\\kanban.txt";

        public List<UsuarioModel> lerUsuarios()
        {
            string textoArquivo = File.ReadAllText(path_usuario);
            List<UsuarioModel> lista = new List<UsuarioModel>();
            if(textoArquivo!="")
                lista = new JavaScriptSerializer().Deserialize<List<UsuarioModel>>(textoArquivo);

            List<UsuarioModel> listaOrdernada = new List<UsuarioModel>();
            if (lista.Count > 0) { listaOrdernada = lista.OrderBy(x => x.id_user).ToList(); }

            return listaOrdernada;
        }

        public List<RepublicaModel> lerRepublicas()
        {
            string textoArquivo = File.ReadAllText(path_republica);
            List<RepublicaModel> lista = new List<RepublicaModel>();
            if (textoArquivo != "")
                lista = new JavaScriptSerializer().Deserialize<List<RepublicaModel>>(textoArquivo);

            List<RepublicaModel> listaOrdernada = new List<RepublicaModel>();
            if (lista.Count > 0) { listaOrdernada = lista.OrderBy(x => x.id_rep).ToList(); }

            return listaOrdernada;
        }

        public List<KanbanModel> lerKanban()
        {
            string textoArquivo = File.ReadAllText(path_kanban);
            List<KanbanModel> lista = new List<KanbanModel>();
            if (textoArquivo != "")
                lista = new JavaScriptSerializer().Deserialize<List<KanbanModel>>(textoArquivo);

            List<KanbanModel> listaOrdernada = new List<KanbanModel>();
            if (lista.Count > 0) { listaOrdernada = lista.OrderBy(x => x.id_rep).ToList(); }

            return listaOrdernada;
        }

        public void Reescrever(Type tipo, string texto)
        {
            if (tipo == typeof(UsuarioModel))
            {
                File.WriteAllText(path_usuario, texto);
            }
            else if (tipo == typeof(RepublicaModel))
            {
                File.WriteAllText(path_republica, texto);
            }
            else if (tipo == typeof(KanbanModel))
            {
                File.WriteAllText(path_kanban, texto);
            }
            else { throw new Exception("Tipo desconhecido"); }
        }
        #endregion
    }
}