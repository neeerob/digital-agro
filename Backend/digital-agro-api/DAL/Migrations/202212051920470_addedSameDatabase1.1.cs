namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSameDatabase11 : DbMigration
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
                "dbo.ConfirmInvestments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        InvestedAmmount = c.Single(nullable: false),
                        ReturnedAmmount = c.Single(),
                        Status = c.String(nullable: false, maxLength: 10),
                        Publishtime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvestLands", t => t.LandId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.LandId)
                .Index(t => t.UserId);
            
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
                        OwnerId = c.Int(nullable: false),
                        Publishtime = c.DateTime(nullable: false),
                        ExpectedCompleteTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
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
            
            CreateTable(
                "dbo.ConfirmLeases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PayedPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaseLands", t => t.LandId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.LandId)
                .Index(t => t.UserId);
            
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
                        OwnerId = c.Int(nullable: false),
                        Publishtime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ConfirmInvestments", "LandId", "dbo.InvestLands");
            DropForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "LandId", "dbo.LeaseLands");
            DropForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users");
            DropIndex("dbo.LeaseLands", new[] { "OwnerId" });
            DropIndex("dbo.ConfirmLeases", new[] { "UserId" });
            DropIndex("dbo.ConfirmLeases", new[] { "LandId" });
            DropIndex("dbo.InvestLands", new[] { "OwnerId" });
            DropIndex("dbo.ConfirmInvestments", new[] { "UserId" });
            DropIndex("dbo.ConfirmInvestments", new[] { "LandId" });
            DropTable("dbo.LeaseLands");
            DropTable("dbo.ConfirmLeases");
            DropTable("dbo.Users");
            DropTable("dbo.InvestLands");
            DropTable("dbo.ConfirmInvestments");
            DropTable("dbo.Admins");
        }
    }
}
