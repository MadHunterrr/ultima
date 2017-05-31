using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class HouseNutzung
    {
        public HouseNutzung()
        {

        }
        [Key]
        [ForeignKey("House")]
        public int Id { set; get; }
        public int? HouseNutzingGew { set; get; }
        public double? HouseNutzingGesamt { set; get; }
        public string HouseNutzingWohn { set; get; }

        public House House { set; get; }
    }
}