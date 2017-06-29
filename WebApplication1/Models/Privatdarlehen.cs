using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Privatdarlehen
    {
        public string antragssumme { set; get; }

        public string bank { set; get; }
        public string barauszahlung { set; get; }
        public string bemerkungen { set; get; }
        public string darlehensbetrag { set; get; }
        public string effektiver { set; get; }
        public string ersteRate_datum { set; get; }
        public string ersteRate_eur { set; get; }
        public string gesamtkreditbetrag { set; get; }
        public string gesamtprovision_eur { set; get; }
        public string kreditbetrag { set; get; }
        public string kreditgebuhren { set; get; }
        public string laufzeit { set; get; }
        public string laufzeitInMonaten { set; get; }
        public string letzteRate { set; get; }
        public string letzteRateDatum { set; get; }
        public string monatlicheRate { set; get; }
        public string packing_eur { set; get; }
        public string packing_pc { set; get; }
        public string provisionBank { set; get; }
        public string provisionBerater_eur { set; get; }
        public string provisionRestschuldversicherung_eur { set; get; }
        public string provisionRestschuldversicherung_pc { set; get; }
        public string vermittlungscourtage { set; get; }
        public string vermittlungscourtage_eur { set; get; }

        public string vertragsnummer { set; get; }
        public string zinsbelastung { set; get; }
        public Restchuldversicherung restchuldversicherung { set; get; }
        public FamilyUnion FamilyUnion { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrivatdarlehenId { set; get; }
    }
}