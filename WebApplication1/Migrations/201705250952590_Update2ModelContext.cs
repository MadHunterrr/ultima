namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2ModelContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenBenefit", c => c.Int());
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenRevenu", c => c.Int());
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenKindergeId", c => c.Int());
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenUnterhaltseinnahmen", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenUnterhaltseinnahmen", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenKindergeId", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenRevenu", c => c.Int(nullable: false));
            AlterColumn("dbo.FamilyChildrens", "FamilyChildrenBenefit", c => c.Int(nullable: false));
        }
    }
}
