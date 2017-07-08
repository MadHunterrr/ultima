using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Bankverbindung
    {
        public Bankverbindung()
        {

        }

        public string kont { get; set; }
        public string iban { get; set; }
        public string bic { get; set; }
        public string num { get; set; }
        public string blz { get; set; }
        public string cred_inst { get; set; }
    }
}