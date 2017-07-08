using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Wi
    {
        public Wi()
        {

        }

        public List<Darlehen> darlehens { get; set; }
        public string genutzt { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public string plz { get; set; }
        public string ort { get; set; }
        public string marktwert { get; set; }
        public string gesamte { get; set; }
    }
}