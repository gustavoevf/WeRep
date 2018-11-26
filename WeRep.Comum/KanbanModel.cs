using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeRep.Models
{
    public class KanbanModel
    {
        public int id_nota { get; set; }
        public int id_rep { get; set; }

        [Required]
        public string mensagem { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime vencimento { get; set; }

        public string cor { get; set; }
    }
}