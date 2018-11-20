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
        public List<KanbanModel> RetornarKanban()
        {
            //void ObterNomeDaCor()
            //{

            //};
            var SessionObj = (UsuarioModel)Session["user"];

            var kanbanBLL = new KanbanBLL();
            return kanbanBLL.RetornarKanban((int)SessionObj.id_rep, null);
        }
    }
}