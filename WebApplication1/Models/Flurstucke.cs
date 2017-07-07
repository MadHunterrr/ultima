using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Flurstucke
    {
        public Flurstucke()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlurstuckeId { get; set; }
        public string Flur { get; set; }
        public string Flurstuck { get; set; }
        public string Anteil { get; set; }
        public string Emp { get; set; }
        public string GroBe { get; set; }
        public int? f_id { set; get; }
    }
}