using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FamilyChildren
    {
        public FamilyChildren()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyChildrenId { set;get;}
        public string FamilyChildrenName { set; get; }
        public string FamilyChildreGeburtsdatum { set; get; }
        public int? FamilyChildrenKindergeId { set; get; }
        public int? FamilyChildrenUnterhaltseinnahmen { set; get; }
        public FamilyUnion FamilyUnion { set; get; }
    }
}