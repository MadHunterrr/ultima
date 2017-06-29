using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Zinsabsicherung
    {
        public string abschlussgebuhr { set; get; }
        public string abtreten { set; get; }
        public string auszahlungszeitpunkt { set; get; }
        public string bausparwunschAnpassen { set; get; }
        public string darlehensbetrag { set; get; }
        public string freiBesparen { set; get; }
        public string sondertilgung { set; get; }
        public string tarif { set; get; }
        public string verrechnung { set; get; }
        public string vertragspartner { set; get; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZinsabsicherungId { set; get; }
        public virtual FamilyUnion FamilyUnion { set; get; }
    }
}