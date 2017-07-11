using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Benutzer
    {
        public Benutzer()
        {

        }

        [Key]
        public int BenutzerId { get; set; }
        public long AuthKey { get; set; }
        public byte PrimaryRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}