using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Datei
    {
        public Datei()
        {

        }

        [Key]
        public int DateiId { get; set; }
        public string FileName { get; set; }
        public string LocalFileName { get; set; }
        public string DownloadLink { get; set; }
        public int EntryId { get; set; }
    }
}