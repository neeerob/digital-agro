namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimeAddedInConfirmLease_Requred : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConfirmLeases", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConfirmLeases", "CreatedDate", c => c.DateTime());
        }
    }
}
