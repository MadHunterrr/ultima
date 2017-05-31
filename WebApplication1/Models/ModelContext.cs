using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ModelContext:DbContext
    {
        public ModelContext()
            : base("ModelContext")
        {

        }
        public DbSet<FamilyUnion> FamilyUnions { set; get; }
        public DbSet<FamilyMem> FamilyMems { set; get; }
        public DbSet<FamilyFinancialSituation> FamilyFinancialSituations { set; get; }
        public DbSet<FamilyChildren> FamilyChildrens { set; get; }
        public DbSet<House> House { set; get; }
        public DbSet<StellPlatze> StellPlatze { set; get; }
        public DbSet<HouseZusat> HouseZusat { set; get; }
        public DbSet<HouseNutzung> HouseNutzung { set; get; }
    }
}