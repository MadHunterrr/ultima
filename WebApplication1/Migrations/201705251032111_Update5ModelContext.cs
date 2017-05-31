namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5ModelContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FamilyChildrens", "FamilyChildrenBenefit");
            DropColumn("dbo.FamilyChildrens", "FamilyChildrenRevenu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FamilyChildrens", "FamilyChildrenRevenu", c => c.Int());
            AddColumn("dbo.FamilyChildrens", "FamilyChildrenBenefit", c => c.Int());
        }
    }
}
