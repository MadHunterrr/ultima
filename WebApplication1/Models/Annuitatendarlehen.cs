using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Annuitatendarlehen
    {

        public string bereit { set; get; }
        public string darlehensbetrag { set; get; }
        public string sondertilgung { set; get; }
        public string tilgungswunschValue { set; get; }
        public string tilgungswunschName { set; get; }
        public string zinsbindung { set; get; }
        public virtual FamilyUnion FamilyUnion { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnnuitatendarlehenId { set; get; }
    }
}