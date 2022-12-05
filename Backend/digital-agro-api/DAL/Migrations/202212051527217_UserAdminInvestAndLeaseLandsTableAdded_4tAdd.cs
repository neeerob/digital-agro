namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdminInvestAndLeaseLandsTableAdded_4tAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Email = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvestLands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 50),
                        WhichCrops = c.String(nullable: false),
                        Moneyneed = c.Double(nullable: false),
                        Estimatedprofit = c.Double(nullable: false),
                        Landsize = c.Double(nullable: false),
                        Discription = c.String(nullable: false, maxLength: 150),
                        District = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Totalinvestedammount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaseLands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 50),
                        District = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Landsize = c.Double(nullable: false),
                        Discription = c.String(nullable: false, maxLength: 150),
                        Status = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Email = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 50),
                        District = c.String(nullable: false, maxLength: 15),
                        Wallet = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.LeaseLands");
            DropTable("dbo.InvestLands");
            DropTable("dbo.Admins");
        }
    }
}
