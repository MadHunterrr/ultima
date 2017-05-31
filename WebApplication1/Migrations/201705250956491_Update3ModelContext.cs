namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3ModelContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyMems", "FamilyMemCode", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemArt", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemCountry", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemFamily", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemNetto", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemPlz", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemSex", c => c.Int());
            AlterColumn("dbo.FamilyMems", "FamilyMemStreetNum", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyMems", "FamilyMemStreetNum", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemSex", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemPlz", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemNetto", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemFamily", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemCountry", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemArt", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyMems", "FamilyMemCode", c => c.Int(nullable: false));
        }
    }
}
