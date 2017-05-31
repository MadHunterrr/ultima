using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FamilyFinancialSituation
    {
        public FamilyFinancialSituation()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyFinancialSituationId { set; get; }
        public string FamilyFinancialSituationBankSparguthaben { set; get; }
        public string FamilyFinancialSituationWertpapiereAktien { set; get; }
        public string FamilyFinancialSituationBausparvertrag{ set; get; }
        public string FamilyFinancialSituationLebensRentenversicherung { set; get; }
        public string FamilyFinancialSituationSparplane { set; get; }
        public string FamilyFinancialSituationSonstigesVermogen { set; get; }
        public string FamilyFinancialSituationEinkunfteNebentatigkeit { set; get; }
        public string FamilyFinancialSituationEnbefristeteZusatzrente { set; get; }
        public string FamilyFinancialSituationEhegattenunterhalt { set; get; }
        public string FamilyFinancialSituationVariableEinkunfte { set; get; }
        public string FamilyFinancialSituationSonstigeEinnahmen { set; get; }
        public string FamilyFinancialSituationMietausgaben { set; get; }
        public string FamilyFinancialSituationUnterhaltsverpflichtungen { set; get; }
        public string FamilyFinancialSituationPrivateKrankenversicherung { set; get; }
        public string FamilyFinancialSituationSonstigeAusgaben { set; get; }
        public string FamilyFinancialSituationSonstigeVersicherungsausgaben { set; get; }
        public string FamilyFinancialSituationRatenkreditLeasing { set; get; }
        public string FamilyFinancialSituationPrivatesDarlehen { set; get; }
        public string FamilyFinancialSituationSonstigeVerbindlichkeiten { set; get; }
    }
}