namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelContextMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyChildrens",
                c => new
                    {
                        FamilyChildrenId = c.Int(nullable: false, identity: true),
                        FamilyChildrenName = c.String(),
                        FamilyChildreGeburtsdatum = c.String(),
                        FamilyChildrenBenefit = c.Int(nullable: true),
                        FamilyChildrenRevenu = c.Int(nullable: true),
                        FamilyChildrenKindergeId = c.Int(nullable: true),
                        FamilyChildrenUnterhaltseinnahmen = c.Int(nullable: true),
                        FamilyUnion_FamilyUnionId = c.Int(),
                    })
                .PrimaryKey(t => t.FamilyChildrenId)
                .ForeignKey("dbo.FamilyUnions", t => t.FamilyUnion_FamilyUnionId)
                .Index(t => t.FamilyUnion_FamilyUnionId);
            
            CreateTable(
                "dbo.FamilyUnions",
                c => new
                    {
                        FamilyUnionId = c.Int(nullable: false, identity: true),
                        FamilyUnionFirstMemberId = c.Int(nullable: false),
                        FamilyUnionSecondMemberId = c.Int(nullable: false),
                        FamilyUnionFinancialSituationid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FamilyUnionId);
            
            CreateTable(
                "dbo.FamilyFinancialSituations",
                c => new
                    {
                        FamilyFinancialSituationId = c.Int(nullable: false, identity: true),
                        FamilyFinancialSituationBankSparguthaben = c.String(),
                        FamilyFinancialSituationWertpapiereAktien = c.String(),
                        FamilyFinancialSituationBausparvertrag = c.String(),
                        FamilyFinancialSituationLebensRentenversicherung = c.String(),
                        FamilyFinancialSituationSparplane = c.String(),
                        FamilyFinancialSituationSonstigesVermogen = c.String(),
                        FamilyFinancialSituationEinkunfteNebentatigkeit = c.String(),
                        FamilyFinancialSituationEnbefristeteZusatzrente = c.String(),
                        FamilyFinancialSituationEhegattenunterhalt = c.String(),
                        FamilyFinancialSituationVariableEinkunfte = c.String(),
                        FamilyFinancialSituationSonstigeEinnahmen = c.String(),
                        FamilyFinancialSituationMietausgaben = c.String(),
                        FamilyFinancialSituationUnterhaltsverpflichtungen = c.String(),
                        FamilyFinancialSituationPrivateKrankenversicherung = c.String(),
                        FamilyFinancialSituationSonstigeAusgaben = c.String(),
                        FamilyFinancialSituationSonstigeVersicherungsausgaben = c.String(),
                        FamilyFinancialSituationRatenkreditLeasing = c.String(),
                        FamilyFinancialSituationPrivatesDarlehen = c.String(),
                        FamilyFinancialSituationSonstigeVerbindlichkeiten = c.String(),
                    })
                .PrimaryKey(t => t.FamilyFinancialSituationId);
            
            CreateTable(
                "dbo.FamilyMems",
                c => new
                    {
                        FamilyMemId = c.Int(nullable: false, identity: true),
                        FamilyMemFirstName = c.String(),
                        FamilyMemSecondName = c.String(),
                        FamilyMemCode = c.Int(nullable: true),
                        FamilyMemComment = c.String(),
                        FamilyMemArt = c.Int(nullable: true),
                        FamilyMemCountry = c.Int(nullable: true),
                        FamilyMemDate = c.String(),
                        FamilyMemFamily = c.Int(nullable: true),
                        FamilyMemNetto = c.Int(nullable: true),
                        FamilyMemOrt = c.String(),
                        FamilyMemPhone = c.String(),
                        FamilyMemPlz = c.Int(nullable: true),
                        FamilyMemSeit = c.String(),
                        FamilyMemSex = c.Int(nullable: true),
                        FamilyMemStreetName = c.String(),
                        FamilyMemStreetNum = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.FamilyMemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyChildrens", "FamilyUnion_FamilyUnionId", "dbo.FamilyUnions");
            DropIndex("dbo.FamilyChildrens", new[] { "FamilyUnion_FamilyUnionId" });
            DropTable("dbo.FamilyMems");
            DropTable("dbo.FamilyFinancialSituations");
            DropTable("dbo.FamilyUnions");
            DropTable("dbo.FamilyChildrens");
        }
    }
}
