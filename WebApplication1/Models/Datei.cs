using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Datei
    {
        public Datei()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DateiId { get; set; }
        public string FileName { get; set; }
        public string LocalFileName { get; set; }
        public int FamilyUnionId { get; set; }
        public string DownloadLink { get; set; }
    }
}