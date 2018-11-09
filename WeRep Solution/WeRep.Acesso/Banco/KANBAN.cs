using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acesso.Banco
{
    public class KANBAN
    {
        public int id_nota { get; set; }
        public int id_rep { get; set; }
        public string mensagem { get; set; }
        public DateTime vencimento { get; set; }
        public int cor { get; set; }
    }
}