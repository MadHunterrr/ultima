using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Bankverbindung
    {
        public Bankverbindung()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankverbindungId { get; set; }
        public int Kont { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Num { get; set; }
        public string Blz { get; set; }
        public string Cred_inst { get; set; }
        public virtual FamilyUnion FamilyUnion { set; get; }
    }
}