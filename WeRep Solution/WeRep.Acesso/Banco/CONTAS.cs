using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acesso.Banco
{
    public class CONTAS
    {
        public int id_conta { get; set; }
        public int id_rep { get; set; }
        public int valor { get; set; }
        public DateTime? expedicao { get; set; }
        public DateTime vencimento { get; set; }
        public string nome { get; set; }
    }
}