using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Anfarrb
    {

        public string anfrageabgelehnt { set; get; }
        public string auftragseingang { set; get; }
        public string betrag { set; get; }
        public string fieldFour { set; get; }
        public string fieldOne { set; get; }
        public string fieldTwo { set; get; }
        public string fieldThree { set; get; }
        public string reason { set; get; }
        public string wiedervorlage { set; get; }

        public virtual FamilyUnion FamilyUnion { set; get; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnfarrbId { set; get; }

    }
}