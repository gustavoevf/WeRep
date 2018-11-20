using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using System.Web.Script.Serialization;

namespace Acesso
{
    public class KanbanDAL : Utilidades
    {
        public void CriarKanban(KanbanModel novo_kanban)
        {
            var lista = lerKanban();

            if (lista.Count > 0)
                novo_kanban.id_nota = lista.Last().id_nota + 1;
            else
                novo_kanban.id_nota = 1;
            lista.Add(novo_kanban);

            Reescrever(typeof(KanbanModel), new JavaScriptSerializer().Serialize(lista));
        }

        public List<KanbanModel> RetornarKanban(int id_rep, int? cor)
        //Se 'int? cor' == null, todas as cores devem ser retornadas
        {
            var lista = lerKanban();
            lista.RemoveAll(x => x.id_rep != id_rep);
            lista.RemoveAll(x => x.vencimento < DateTime.Now);

            if (cor == null)
                return lista;

            lista.RemoveAll(x => x.cor != cor);
            return lista;
        }

        public List<KanbanModel> RetornarKanban(int id_rep, string texto, int? cor)
        {
            var lista = lerKanban();
            lista.RemoveAll(x => x.id_rep != id_rep);
            lista.RemoveAll(x => x.vencimento < DateTime.Now);
            if (cor != null)
                lista.RemoveAll(x => x.cor != cor);
            List<KanbanModel> lista_filtrada = new List<KanbanModel>();

            foreach (KanbanModel item in lista)
                if (item.mensagem.Contains(texto))
                    lista_filtrada.Add(item);

            return lista_filtrada;
        }

    }
}