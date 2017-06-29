using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Kwf
    {
        public Kwf()
        {
            items = new List<Item>();
        }
        public int? curent { set; get; }
        public string darlehensbetrag { set; get; }
        public string laufzeit { set; get; }
        public string linkName { set; get; }
        public string name { set; get; }
        public int? max { set; get; }
        public virtual FamilyUnion FamilyUnion { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KwfId { set; get; }
        public virtual ICollection<Item> items { set; get; }
    }
}