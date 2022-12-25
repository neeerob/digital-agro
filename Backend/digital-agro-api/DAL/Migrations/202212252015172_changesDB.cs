namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesDB : DbMigration
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
                "dbo.GovmentOfficials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 255),
                        District = c.String(nullable: false, maxLength: 15),
                        Admins_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admins_Id)
                .Index(t => t.Admins_Id);
            
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
                        GovmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GovmentOfficials", t => t.GovmentId)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.GovmentId);
            
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
                        InvestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvestLands", t => t.LandId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.LandId)
                .Index(t => t.UserId);
            
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
                        CreatedDate = c.DateTime(nullable: false),
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
                        GovmentId = c.Int(),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GovmentOfficials", t => t.GovmentId)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.GovmentId);
            
            CreateTable(
                "dbo.CloseInvests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandId = c.Int(nullable: false),
                        ReturnAmmount = c.Double(nullable: false),
                        Status = c.String(),
                        CloseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Token_Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        Username = c.String(nullable: false),
                        logId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Token_Govment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        Username = c.String(nullable: false),
                        logId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Token_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        Username = c.String(nullable: false),
                        logId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 35),
                        ReceiverId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        Ammount = c.Single(nullable: false),
                        TransactionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.InvestLands", "GovmentId", "dbo.GovmentOfficials");
            DropForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "LandId", "dbo.LeaseLands");
            DropForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.LeaseLands", "GovmentId", "dbo.GovmentOfficials");
            DropForeignKey("dbo.ConfirmInvestments", "LandId", "dbo.InvestLands");
            DropForeignKey("dbo.GovmentOfficials", "Admins_Id", "dbo.Admins");
            DropIndex("dbo.LeaseLands", new[] { "GovmentId" });
            DropIndex("dbo.LeaseLands", new[] { "OwnerId" });
            DropIndex("dbo.ConfirmLeases", new[] { "UserId" });
            DropIndex("dbo.ConfirmLeases", new[] { "LandId" });
            DropIndex("dbo.ConfirmInvestments", new[] { "UserId" });
            DropIndex("dbo.ConfirmInvestments", new[] { "LandId" });
            DropIndex("dbo.InvestLands", new[] { "GovmentId" });
            DropIndex("dbo.InvestLands", new[] { "OwnerId" });
            DropIndex("dbo.GovmentOfficials", new[] { "Admins_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Token_Users");
            DropTable("dbo.Token_Govment");
            DropTable("dbo.Token_Admin");
            DropTable("dbo.Districts");
            DropTable("dbo.CloseInvests");
            DropTable("dbo.LeaseLands");
            DropTable("dbo.ConfirmLeases");
            DropTable("dbo.Users");
            DropTable("dbo.ConfirmInvestments");
            DropTable("dbo.InvestLands");
            DropTable("dbo.GovmentOfficials");
            DropTable("dbo.Admins");
        }
    }
}
