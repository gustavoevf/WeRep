using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class ContaModel
    {
        public int id_conta { get; set; }
        public int id_rep { get; set; }
        public int valor { get; set; }
        public DateTime? expedicao { get; set; }
        public DateTime vencimento { get; set; }
        public string nome { get; set; }
    }
}