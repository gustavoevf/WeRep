﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class RepublicaModel
    {
        public string nome { get; set; }
        public int id_rep { get; set; }
        public int id_adm { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public int capacidade { get; set; }
        public List<int> moradores { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}