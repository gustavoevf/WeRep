using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using Acesso.Banco;
using Helpers;

namespace Acesso
{
    public class RepublicaDAL
    {
        public void InserirRepublica(RepublicaModel republica)
        {
            Mock Banco = new Mock();
            Banco.InserirRepublica(republica);
        }

        public List<RepublicaModel> ExibirRepublicas(SolicitacaoExibirRepublicas dados)
        {
            Mock Banco = new Mock();
            string campo = dados.campo;
            string dado = dados.dado;

            Banco.RetornarRepublicas();
        }

        public bool RepublicaExiste(RepublicaModel republica)
        {
            return false;
        }
    }
}