using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Basisangaben
    {
        [Key]
        public int BasisangabenId { get; set; }
        public int Entry { get; set; }
        public string Wofur { get; set; }
        public string Strabe { get; set; }
        public string Nr { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Art { get; set; }
        public string Grundstucksgrobe { get; set; }
        public string Einliegerwonhnung { get; set; }
        public string Baujahr { get; set; }
        public string Anzahl { get; set; }
        public string Bauweise { get; set; }
        public string Fertighaus { get; set; }
        public string Keller { get; set; }
        public string Dachgeschoss { get; set; }
        public string Gesamte { get; set; }
        public string Wie { get; set; }
        public string Gewerbeflache { get; set; }
        public string Erbbaurecht { get; set; }
        public string Wurde { get; set; }
    }
}