﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class UsuarioModel
    {
        public int? id_rep { get; set; }
        public int? id_user { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public int tipo { get; set; }
    }
}