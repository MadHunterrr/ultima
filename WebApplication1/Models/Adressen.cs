using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Adressen
    {
        public Adressen()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdressenId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}