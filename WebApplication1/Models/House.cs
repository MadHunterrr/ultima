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
        public string HouseBankverbingin { set; get; }
        public string HouseArt { set; get; }
        public double HouseBaujahr { set; get; }
        public int HouseBauweiseAndere { set; get; }
        public int HiuseBauweiseMassiv { set; get; }
        public string HouseDacherous { set; get; }
        public int? HouseEin { set; get; }
        public int? HouseFer { set; get; }
        public string HouseGrund { set; get; }
        public string HouseNr { set; get; }
        public string HouseOrt { set; get; }
        public string HousePlz { set; get; }
        public string HouseVall { set; get; }
        public string HouseKeller { set; get; }
        public string HouseStrebe { set; get; }
        public HouseNutzung HouseNutzung { set; get; }
        public HouseZusat HouseZusat { set; get; }
        public StellPlatze StellPlatze { set; get; }
    }
}