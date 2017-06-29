using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class HouseZusat
    {
        public HouseZusat()
        {

        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HouseZusatId { set; get; }
        public int? erbbaurecht { set; get; }
        public int? objekt { set; get; }
        public int? f_id { set; get; }
    }
}