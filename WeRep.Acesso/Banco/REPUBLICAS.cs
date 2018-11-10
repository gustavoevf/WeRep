using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acesso.Banco
{
    public class REPUBLICAS
    {
        public int id_rep { get; set; }
        public int id_adm { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public int capacidade { get; set; }
        List<int> moradores { get; set; }
    }
}