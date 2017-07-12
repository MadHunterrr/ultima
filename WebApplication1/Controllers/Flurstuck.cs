using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Flurstucke
    {
        [Key]
        public int FlurstuckeId { get; set; }
        public int Entry { get; set; }
        public string Flur { get; set; }
        public string Flurstuck { get; set; }
        public string Anteil { get; set; }
        public string Anteil2 { get; set; }
        public string DesFlurs { get; set; }
    }
}
