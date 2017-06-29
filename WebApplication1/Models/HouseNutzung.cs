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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HouseNutzungId { set; get; }
        public int? gewerbeflache { set; get; }
        public double? gesamtewohnflache { set; get; }
        public string wohnflache { set; get; }
        public int? f_id { set; get; }
       
    }
}