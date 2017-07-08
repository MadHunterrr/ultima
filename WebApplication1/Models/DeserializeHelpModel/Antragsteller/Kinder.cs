using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Kinder
    {
        public Kinder()
        {

        }

        public string name { get; set; }
        public string geburtsdatum { get; set; }
        public string unterhaltseinnahmen { get; set; }
        public string kindergeld { get; set; }
    }
}