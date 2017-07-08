using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DeserializeHelpModel.Antragsteller
{
    public class Banks
    {
        public Banks()
        {

        }

        public List<Left> left { get; set; }
        public List<Right> right { get; set; }
    }
}