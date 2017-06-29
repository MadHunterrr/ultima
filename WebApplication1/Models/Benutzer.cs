using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Benutzer
    {
        public Benutzer()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenutzerId { get; set; }
        public long AuthKey { get; set; }
        public byte PrimaryRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}