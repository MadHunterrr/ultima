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
            Anfarras = new List<Anfarra>();
            Anfarrbs = new List<Anfarrb>();
            Kwfs = new List<Kwf>();
            Zinsabsicherungs = new List<Zinsabsicherung>();
            Privatdarlehens = new List<Privatdarlehen>();
            Forwarddarlehens = new List<Forwarddarlehen>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int FamilyUnionId { set; get;}
     
        public int FirstFamilyMember { set; get; }
       
        public int SecondFamilyMember { set; get; }
        
        public int FamilyFinacialSituationId { set; get; }
      
        public virtual ICollection<FamilyChildren> FamilyChildrens { set; get; }
        public virtual ICollection<Anfarra> Anfarras { set; get; }
        public virtual ICollection<Anfarrb> Anfarrbs { set; get; }
        public virtual ICollection<Zinsabsicherung> Zinsabsicherungs { set; get; }
        public virtual ICollection<Kwf> Kwfs { set; get; }
        public virtual ICollection<Privatdarlehen> Privatdarlehens { set; get; }
        public virtual ICollection<Forwarddarlehen> Forwarddarlehens { set; get; }
        public virtual ICollection<VariablesDarlehen> VariableDarlehens { set; get; }
        public virtual ICollection<Annuitatendarlehen> Annuitatendarlehens { set; get; }

    }
}