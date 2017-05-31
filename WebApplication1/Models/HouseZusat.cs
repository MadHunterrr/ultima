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
        [ForeignKey("House")]
        public int Id { set; get; }
        public int? HouseZusatErb { set; get; }
        public int? HouseZusatObj { set; get; }
        public House House { set; get; }
    }
}