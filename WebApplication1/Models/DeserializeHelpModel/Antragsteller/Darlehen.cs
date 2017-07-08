using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Darlehen
    {
        public Darlehen()
        {

        }

        public string darlehensart { get; set; }
        public string grundschuld { get; set; }
        public string rate { get; set; }
        public string aktuelle_restschuld { get; set; }
        public string zinsbindung_bis { get; set; }
        public string laufzeit_bis { get; set; }
    }
}