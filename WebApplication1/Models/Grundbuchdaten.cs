using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Grundbuchdaten
    {
        public Grundbuchdaten()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GrundbuchdatenId { get; set; }
        public string Grundbuch { get; set; }
        public string Blatt { get; set; }
        public string Betrag { get; set; }
        public string Beschreibung { get; set; }
        public string Anmerkungen { get; set; }
        public int? f_id { set; get; }
    }
}