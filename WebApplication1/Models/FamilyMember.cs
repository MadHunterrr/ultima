using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Code { get; set; }
        public string Comment { get; set; }
        public int Art { get; set; }
        public int Country { get; set; }
        public string Date { get; set; }
        public int Family { get; set; }
        public int Netto { get; set; }
        public string Ort { get; set; }
        public int Phone { get; set; }
        public int Plz { get; set; }
        public string Seit { get; set; }
        public int Sex { get; set; }
        public string StreetName { get; set; }
        public int StreetNum { get; set; }
    }
}