using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Item
    {
        public int? a { set; get; }
        public int? darlehensbetrag { set; get; }
        public int? laufzeit { set; get; } 
        public virtual Kwf Kwf { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { set; get; }
    }
}