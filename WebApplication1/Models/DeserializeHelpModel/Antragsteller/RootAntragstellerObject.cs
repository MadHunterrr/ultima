using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class RootAntragstellerObject
    {
        public RootAntragstellerObject()
        {

        }

        public Antragsteller1 antragsteller1 { get; set; }
        public Antragsteller2 antragsteller2 { get; set; }
        public List<Kinder> kinders { get; set; }
        public Banks banks { get; set; }
        public List<Bankverbindung> bankverbindungs { get; set; }
        public List<Wi> wis { get; set; }
    }
}