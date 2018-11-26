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

        public ActionResult InserirKanban(int id_rep)
        {
            Session["id_rep"] = id_rep;

            var viewModel = new KanbanModel();
            viewModel.id_rep = id_rep;
            return View(viewModel);
        }

        public ActionResult Index(int id_rep)
        {
            var kanban = RetornarKanban(id_rep);

            return View(kanban);
        }

        [HttpPost]
        public ActionResult InserirKanban(KanbanModel msg)
        {
            var session_rep = (int)Session["id_rep"];
            msg.id_rep = session_rep;
            msg.vencimento = msg.vencimento.Date;
            new KanbanBLL().CriarKanban(msg);
            return RedirectToAction("Index", "Kanban", new { id_rep = msg.id_rep });
        }

        //private int CalcularCor(string cor)
        //{
        //    if (cor == "Green")
        //        return 1;
        //    if (cor == "Yellow")
        //        return 2;
        //    if (cor == "Red")
        //        return 3;
        //    if (cor == "Blue")
        //        return 4;
        //    if (cor == "Pink")
        //        return 5;
        //    else return 0;
        //}
    }
}