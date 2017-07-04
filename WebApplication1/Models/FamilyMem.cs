using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FamilyMem
    {
        public FamilyMem()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyMemId { get; set; }
        public string FamilyMemFirstName { get; set; }
        public string FamilyMemSecondName { get; set; }
        public int? FamilyMemCode { get; set; }
        public string FamilyMemComment { get; set; }
        public int? FamilyMemArt { get; set; }
        public int? FamilyMemCountry { get; set; }
        public string FamilyMemDate { get; set; }
        public int? FamilyMemFamily { get; set; }
        public int? FamilyMemNetto { get; set; }
        public string FamilyMemOrt { get; set; }
        public string FamilyMemPhone { get; set; }
        public int? FamilyMemPlz { get; set; }
        public string FamilyMemSeit { get; set; }
        public int? FamilyMemSex { get; set; }
        public string FamilyMemStreetName { get; set; }
        public int? FamilyMemStreetNum { get; set; }
        public string FamilyMemEmail { set; get; }
        public bool? FamilyMemProf { set; get; }
        public bool? FamilyMemDoctor { set; get; }
        public bool? FamilyAddress { get; set; }
    }
}