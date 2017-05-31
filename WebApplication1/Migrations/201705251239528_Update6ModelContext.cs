namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6ModelContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseBankverbingin = c.String(),
                        HouseArt = c.String(),
                        HouseBaujahr = c.Double(nullable: false),
                        HouseBauweise = c.String(),
                        HouseDacherous = c.String(),
                        HouseEin = c.Int(),
                        HouseFer = c.Int(),
                        HouseGrund = c.String(),
                        HouseNr = c.String(),
                        HouseOrt = c.String(),
                        HousePlz = c.String(),
                        HouseVall = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseNutzungs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HouseNutzingGew = c.Int(),
                        HouseNutzingGesamt = c.Double(),
                        HouseNutzingWohn = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HouseZusats",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HouseZusatErb = c.Int(),
                        HouseZusatObj = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.StellPlatzes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StellPlatzeStell = c.String(),
                        StellPlatzeCarport = c.String(),
                        StellPlatzeGerage = c.String(),
                        StellPlatzeDop = c.String(),
                        StellPlatzeKeller = c.String(),
                        StellPlatzeTief = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StellPlatzes", "Id", "dbo.Houses");
            DropForeignKey("dbo.HouseZusats", "Id", "dbo.Houses");
            DropForeignKey("dbo.HouseNutzungs", "Id", "dbo.Houses");
            DropIndex("dbo.StellPlatzes", new[] { "Id" });
            DropIndex("dbo.HouseZusats", new[] { "Id" });
            DropIndex("dbo.HouseNutzungs", new[] { "Id" });
            DropTable("dbo.StellPlatzes");
            DropTable("dbo.HouseZusats");
            DropTable("dbo.HouseNutzungs");
            DropTable("dbo.Houses");
        }
    }
}
