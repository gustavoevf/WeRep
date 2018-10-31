using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Modules.Kanban
{
    public class Model
    {
        public int Id { get; set; }
        public int IdRepublica { get; set; }
        public string Mensagem { get; set; }
        public string Cor { get; set; }
        public DateTime Vencimento { get; set; }
        public string Nome { get; set; }
    }
}