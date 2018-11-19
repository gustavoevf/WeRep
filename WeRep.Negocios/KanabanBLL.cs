using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acesso;
using WeRep.Models;

namespace WeRep.Negocios
{
    public class KanabanBLL
    {
        public void CriarKanban(KanbanModel novo_kanban)
        {
            new KanbanDAL().CriarKanban(novo_kanban);
        }

        public List<KanbanModel> RetornarKanban(int id_rep, int? cor)
        {
            return new KanbanDAL().RetornarKanban(id_rep, cor);
        }

        public List<KanbanModel> RetornarKanban(int id_rep, string texto)
        {
            return new KanbanDAL().RetornarKanban(id_rep, texto);
        }
    }
}