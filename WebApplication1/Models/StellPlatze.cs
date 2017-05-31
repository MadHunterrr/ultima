using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class StellPlatze
    {
        public StellPlatze()
        {

        }
        [Key]
        [ForeignKey("House")]
        public int Id { set; get; }

        public string StellPlatzeStell { set; get; }
        public string StellPlatzeCarport { set; get; }
        public string StellPlatzeGerage { set; get; }
        public string StellPlatzeDop { set; get; }
        public string StellPlatzeKeller { set; get; }
        public string StellPlatzeTief { set; get; }
        public House House { set; get; }
    }
}