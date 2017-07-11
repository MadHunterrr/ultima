using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Werbung
    {
        public Werbung()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ifnr { get; set; }
        public string Bezeichnung { get; set; }
        public string DS_angelegt { get; set; }
    }
}