using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Kontakt
    {
        public Kontakt()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ifnr { get; set; }
        public string Bezeichnung { get; set; }
        public string DS_angelegt { get; set; }
    }
}