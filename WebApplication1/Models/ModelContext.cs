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
            /*this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;*/
        }
        public DbSet<FamilyUnion> FamilyUnions { set; get; }
        public DbSet<FamilyMem> FamilyMems { set; get; }
        public DbSet<FamilyFinancialSituation> FamilyFinancialSituations { set; get; }
        public DbSet<FamilyChildren> FamilyChildrens { set; get; }
        public DbSet<House> House { set; get; }
        public DbSet<StellPlatze> StellPlatze { set; get; }
        public DbSet<HouseZusat> HouseZusat { set; get; }
        public DbSet<HouseNutzung> HouseNutzung { set; get; }
        public DbSet<Anfarra> Anfarras { set; get; }
        public DbSet<Anfarrb> Anfarrbs { set; get; }
        public DbSet<Privatdarlehen> Privatdarlehen { set; get; }
        public DbSet<Zinsabsicherung> Zinsabsicherungs { set; get; }
        public DbSet<Forwarddarlehen> Forwarddarlehens { set; get; }
        public DbSet<Kwf> Kwfs { set; get; }
        public DbSet<Annuitatendarlehen> Annuitatendarlehens { set; get; } 
        public DbSet<VariablesDarlehen> VariablesDarlehens { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<Benutzer> Benutzers { get; set; }
    }
}