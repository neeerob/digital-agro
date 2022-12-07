namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_transaction_and_seeded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 10),
                        ReceiverId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        Ammount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.SenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "ReceiverId", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "SenderId" });
            DropIndex("dbo.Transactions", new[] { "ReceiverId" });
            DropTable("dbo.Transactions");
        }
    }
}
