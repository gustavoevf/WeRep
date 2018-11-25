using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using WeRep.Negocios;
using System.Web.Mvc;

namespace WeRep.Controllers
{
    public class KanbanController : Controller
    {
        public List<KanbanModel> RetornarKanban(int id_rep)
        {
            var kanbanBLL = new KanbanBLL();
            return kanbanBLL.RetornarKanban(id_rep, null);
        }

        public ActionResult Index(int id)
        {
            var kanban = RetornarKanban(id);

            return View(kanban);
        }
    }
}