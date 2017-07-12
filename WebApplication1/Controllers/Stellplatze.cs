using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Stellplatze
    {
        [Key]
        public int StellplatzeId { get; set; }
        public int Entry { get; set; }
        public string Name { get; set; }
        public int Current { get; set; }
        public string Id { get; set; }
        public int Max { get; set; }
        public int Vermietet { get; set; }
    }
}
