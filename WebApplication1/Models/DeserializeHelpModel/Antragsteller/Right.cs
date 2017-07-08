using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Right
    {
        public Right()
        {

        }

        public string id { get; set; }
        public string side { get; set; }
        public string betrag { get; set; }
        public bool entfallen_finanzierung { get; set; }
        public string rate { get; set; }
        public string glaubiger { get; set; }
        public string aktuelle_restschuld { get; set; }
        public string laufzeitende { get; set; }
    }
}