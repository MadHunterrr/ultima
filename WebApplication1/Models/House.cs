using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class House
    {
        public House()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string bankverbindung { set; get; }
        public string art { set; get; }
        public double baujahr { set; get; }
        
        public string dachgeschoss { set; get; }
        public int? einliegerwohnung { set; get; }
        public int? fertighaus { set; get; }
        public string grundstucksgrobe { set; get; }
        public string nr { set; get; }
        public string ort { set; get; }
        public string plz { set; get; }
        public string vollgeschosse { set; get; }
        public string keller { set; get; }
        public string strabe { set; get; }
        public int? f_id { set; get; }
        
    }
}