using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using System.Web.Script.Serialization;
using WeRep.Utilidades_namespc;

namespace Acesso
{
    public class RepublicaDAL : Utilidades
    {
        public void CriarRepublica(RepublicaModel nova_rep)
        {
            List<RepublicaModel> lista = lerRepublicas();

            if (lista.Count > 0)
                nova_rep.id_rep = lista.Last().id_rep + 1;
            else
                nova_rep.id_rep = 1;
            lista.Add(nova_rep);

            Reescrever(typeof(RepublicaModel), new JavaScriptSerializer().Serialize(lista));
        }
        
        public void InserirMorador(int id_user, int id_rep)
        {
            List<RepublicaModel> lista = lerRepublicas();
            lista.First(x => x.id_rep == id_rep).moradores.Add(id_user);
            Reescrever(typeof(RepublicaModel), new JavaScriptSerializer().Serialize(lista));

            List<UsuarioModel> lista_users = lerUsuarios();
            lista_users.First(x => x.id_user == id_user).id_rep = id_rep;
            Reescrever(typeof(UsuarioModel), new JavaScriptSerializer().Serialize(lista_users));
        }

        public List<RepublicaModel> GetRepublicaAdm(int id_adm)
        {
            List<RepublicaModel> lista = lerRepublicas();
            if (!lista.Any(x => (x.id_adm == id_adm)))
                return new List<RepublicaModel>();
            return lista.Where(x => (x.id_adm == id_adm)).ToList();
        }

        public List<RepublicaModel> RetornarRepublica(int id_rep)
        {
            List<RepublicaModel> lista = lerRepublicas();
            if (!lista.Any(x => (x.id_rep == id_rep)))
                return new List<RepublicaModel>();
            return lista.Where(x => (x.id_rep == id_rep)).ToList();
        }

        public List<UsuarioModel> ProcurarMorador(int morador, int republica)
        {
            var lista = lerRepublicas();
            if (lista.First(x => x.id_rep == republica).moradores.Any(y => y == morador))
                return new UsuarioDAL().RetornarUsuario(lista.First(x => x.id_rep == republica).moradores.First(y => y == morador));
            else return new List<UsuarioModel>();
        }
    }
}