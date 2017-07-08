using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Left
    {
        public Left()
        {

        }

        public string id { get; set; }
        public string side { get; set; }
        public string githaben { get; set; }
        public string zinsertrag { get; set; }
        public string angesparter_betrag { get; set; }
        public string sparbeitrag { get; set; }
        public string aktueller_wert { get; set; }
        public string beitrag { get; set; }
        public string betrag { get; set; }
        public string beginn_nebentaetigkeit { get; set; }
        public string marktwert { get; set; }
        public string dividenden { get; set; }
        public string ruckkaufswert { get; set; }
        public string pramie { get; set; }
    }
}