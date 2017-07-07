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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StellPlatzeId { set; get; }
        public string Stellplatz { set; get; }
        public string Carport { set; get; }
        public string Garage { set; get; }
        public string Doppelgarage { set; get; }
        public string Kellergarage { set; get; }
        public string Tiefgaragenstellplatz { set; get; }
        public int? f_id { set; get; }
    }
}