namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdTokenTables_nullET : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Token_Admin", "ExpirationTime", c => c.DateTime());
            AlterColumn("dbo.Token_Govment", "ExpirationTime", c => c.DateTime());
            AlterColumn("dbo.Token_Users", "ExpirationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Token_Users", "ExpirationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Token_Govment", "ExpirationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Token_Admin", "ExpirationTime", c => c.DateTime(nullable: false));
        }
    }
}
