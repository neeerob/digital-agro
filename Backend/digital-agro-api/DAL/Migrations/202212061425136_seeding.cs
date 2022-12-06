namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaseLands", "Period", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaseLands", "Period");
        }
    }
}
