using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class RepublicaViewModel
    {
        public string mensagem_add { get; set; }
        
        public int id { get; set; }
        public string nome { get; set; }
        public string adm { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public int capacidade { get; set; }
        public List<string> moradores { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public List<KanbanModel> kanban { get; set; }
    }
}