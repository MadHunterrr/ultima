using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Antragsteller
    {
        public Antragsteller()
        {

        }

        [Key]
        public int AntragstellerId { get; set; }
        public int Entry { get; set; }
        public int Number { get; set; }
        public int Sex { get; set; }
        public string Vorname { get; set; }
        public string SecondName { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string DateBirthd { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Seit { get; set; }
        public string Famili { get; set; }
        public string Country { get; set; }
        public string Art { get; set; }
        public string Netto { get; set; }
        public string Arbeitgeber { get; set; }
        public bool Prof { get; set; }
        public bool Dr { get; set; }
    }
}