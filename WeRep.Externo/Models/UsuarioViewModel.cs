using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class UsuarioViewModel
    {
        public string nome { get; set; }
        public string republica { get; set; }
        public string tipo { get; set; }
        public List<int> republicas_gerenciadas { get; set; }
    }
}