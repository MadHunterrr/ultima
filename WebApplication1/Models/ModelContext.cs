using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Controllers;

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
        public DbSet<Bankverbindung> Bankverbindungs { get; set; }
        // All above will be delete and unuse.
        public DbSet<Antragsteller> Antragstellers { get; set; }
        
        public DbSet<Benutzer> Benutzers { get; set; }
        public DbSet<Werbung> Werbungs { get; set; }
        public DbSet<Kontakt> Kontakts { get; set; }
        public DbSet<Datei> Dateis { get; set; }
        public DbSet<Adressen> Adressens { get; set; }
        public DbSet<Banken> Bankens { get; set; }

        //-----------------
        public DbSet<Basisangaben> Basisangabens { get; set; }
        public DbSet<Stellplatze> Stellplatzes { get; set; }
        public DbSet<Flurstucke> Flurstuckes { get; set; }
    }
}