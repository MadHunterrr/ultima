using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    public class FamilyUnion
    {
        public FamilyUnion()
        {
            FamilyChildrens = new List<FamilyChildren>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyUnionId { set; get; }
        public int FamilyUnionFirstMemberId { set; get; }
        public int FamilyUnionSecondMemberId { set; get; }
        public int FamilyUnionFinancialSituationid { set; get; }

        public ICollection<FamilyChildren> FamilyChildrens { set; get; }
    }
}