using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Adressens
    {
        public Adressens()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdressenId { get; set; }
        public int Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Namenszusatz { get; set; }
        public string Initialen { get; set; }
        public string Firmenname { get; set; }
        public string Branche { get; set; }
        public string Berufsbezeichnung { get; set; }
        public string Abteilung { get; set; }
        public string Adresse { get; set; }
        public string AdresseBeruflich { get; set; }
        public string Landeskurzel { get; set; }
        public string LandeskurzelBeruflich { get; set; }
        public int Postleitzahlen_ID { get; set; }
        public int PLZBeruflich_ID { get; set; }
        public string PLZPrivatText { get; set; }
        public string PLZBeruflichText { get; set; }
        public string Ortsadresse { get; set; }
        public string Postfach { get; set; }
        public string PostfachBeruflich { get; set; }
        public int PLZPostfach { get; set; }
        public int PLZPostfachBeruflich { get; set; }
        public string TelefonPrivat { get; set; }
        public string TelefonBeruflich { get; set; }
        public string Durchwahl_Buro { get; set; }
        public string Faxnummer { get; set; }
        public string FaxBeruflich { get; set; }
        public string Funktelefon { get; set; }
        public string EmailAdresse { get; set; }
        public string EmailAdresse2 { get; set; }
        public string EmailAdresse3 { get; set; }
        public string Homepage { get; set; }
        public string HomepageBeruflich { get; set; }
        public string FTPSeite { get; set; }
        public string Konto_Nr { get; set; }
        public int Bankleitzahl_ID { get; set; }
        public string KontoNrBeruflich { get; set; }
        public int BLZBeruflich { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public DateTime Jahrestag { get; set; }
        public string Anmerkungen { get; set; }
        public bool SendenKarte { get; set; }
        public DateTime AnlegeDatum { get; set; }
        public DateTime LetzteAnderung { get; set; }
        public string FotoPfad { get; set; }
        public string Foto { get; set; }
        public double Rabatt { get; set; }
        public string KundenNr { get; set; }
        public string HandyBeruflich { get; set; }
        public int AnredeB { get; set; }
        public int AAutokennzeichenID { get; set; }
        public bool UmsatzsteuerJN { get; set; }
        public string UmsatzsteuerIdNr { get; set; }
    }
}