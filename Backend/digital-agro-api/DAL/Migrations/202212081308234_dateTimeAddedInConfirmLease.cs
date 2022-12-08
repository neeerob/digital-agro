namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimeAddedInConfirmLease : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConfirmLeases", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfirmLeases", "CreatedDate");
        }
    }
}
