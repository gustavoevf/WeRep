using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class Recursos
    {
        public enum tipoUsuario { Inicial = 1, Morador, Administrador };
        public enum corNome { Green = 1, Yellow, Red, Black, Blue, Pink };
        public enum erroListagem { UsuarioJaExistente = 1, UsuarioInexistente, SenhaErrada };

        public static List<string> cores = new List<string>()
        {
            "Green",
            "Yellow",
            "Red",
            "Black",
            "Blue",
            "Pink"
        };    
    }
}