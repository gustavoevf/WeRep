using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeRep.Models;
using WeRep.Negocios;

namespace WeRep.Controllers
{
    public class RepublicaController : Controller
    {
        public void CriarRepublica(RepublicaModel nova_rep, bool admPresente)
        {
            new RepublicaBLL().CadastrarRepublica(nova_rep, admPresente);
        }

        public void InserirMorador(List<string> moradores, int id_rep)
        {
            new RepublicaBLL().InserirMorador(moradores, id_rep);
        }

        public RepublicaModel RetornarRepublica(int id_rep)
        {
            return new RepublicaBLL().RetornarRepublica(id_rep);
        }

        public List<RepublicaModel> GetRepublicasAdm(int id_adm)
        {
            return new RepublicaBLL().GetRepublicasAdm(id_adm);
        }
    }
}
