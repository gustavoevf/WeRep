using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acesso.Banco;

namespace Acesso.Controllers
{
    public class TesteController
    {
        Mock oi = new Mock();
        public void teste()
        {
            oi.InserirRepublica();
        }
    }
}