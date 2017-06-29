using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Anfarra
    {

        public string anfragen { set; get; }
        public string bearbeiter { set; get; }
        public string erstelltam { set; get; }
        public string field { set; get; }
        public string gedruckt { set; get; }
        public string status { set; get; }
        public string zweck { set; get; }
        public bool? abgerechnet { set; get; }
        public bool? abgelehnt { set; get; }
        public bool? storno { set; get; }

        public virtual FamilyUnion FamilyUnion { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnfarraId { set; get; }
    }
}