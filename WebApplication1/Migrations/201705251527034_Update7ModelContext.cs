namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7ModelContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "HouseBauweiseAndere", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "HiuseBauweiseMassiv", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "HouseKeller", c => c.String());
            AddColumn("dbo.Houses", "HouseStrebe", c => c.String());
            DropColumn("dbo.Houses", "HouseBauweise");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "HouseBauweise", c => c.String());
            DropColumn("dbo.Houses", "HouseStrebe");
            DropColumn("dbo.Houses", "HouseKeller");
            DropColumn("dbo.Houses", "HiuseBauweiseMassiv");
            DropColumn("dbo.Houses", "HouseBauweiseAndere");
        }
    }
}
