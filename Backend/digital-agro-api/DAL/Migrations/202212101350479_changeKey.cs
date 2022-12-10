namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CloseInvests", "ReturnAmmount", c => c.Double(nullable: false));
            DropColumn("dbo.CloseInvests", "Ammount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CloseInvests", "Ammount", c => c.Double(nullable: false));
            DropColumn("dbo.CloseInvests", "ReturnAmmount");
        }
    }
}
