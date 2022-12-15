namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdTokenTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Token_Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Token_Govment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Token_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Token_Users");
            DropTable("dbo.Token_Govment");
            DropTable("dbo.Token_Admin");
        }
    }
}
