namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checking_FK_33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users");
            DropForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users");
            DropForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users");
            DropIndex("dbo.ConfirmInvestments", new[] { "InvestLands_Id" });
            DropIndex("dbo.ConfirmLeases", new[] { "LeaseLands_Id" });
            DropColumn("dbo.ConfirmInvestments", "LandId");
            DropColumn("dbo.ConfirmLeases", "LandId");
            RenameColumn(table: "dbo.ConfirmInvestments", name: "InvestLands_Id", newName: "LandId");
            RenameColumn(table: "dbo.ConfirmLeases", name: "LeaseLands_Id", newName: "LandId");
            AlterColumn("dbo.ConfirmInvestments", "LandId", c => c.Int(nullable: false));
            AlterColumn("dbo.ConfirmLeases", "LandId", c => c.Int(nullable: false));
            CreateIndex("dbo.ConfirmInvestments", "LandId");
            CreateIndex("dbo.ConfirmLeases", "LandId");
            AddForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users", "Id");
            AddForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users");
            DropForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users");
            DropIndex("dbo.ConfirmLeases", new[] { "LandId" });
            DropIndex("dbo.ConfirmInvestments", new[] { "LandId" });
            AlterColumn("dbo.ConfirmLeases", "LandId", c => c.Int());
            AlterColumn("dbo.ConfirmInvestments", "LandId", c => c.Int());
            RenameColumn(table: "dbo.ConfirmLeases", name: "LandId", newName: "LeaseLands_Id");
            RenameColumn(table: "dbo.ConfirmInvestments", name: "LandId", newName: "InvestLands_Id");
            AddColumn("dbo.ConfirmLeases", "LandId", c => c.Int(nullable: false));
            AddColumn("dbo.ConfirmInvestments", "LandId", c => c.Int(nullable: false));
            CreateIndex("dbo.ConfirmLeases", "LeaseLands_Id");
            CreateIndex("dbo.ConfirmInvestments", "InvestLands_Id");
            AddForeignKey("dbo.LeaseLands", "OwnerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConfirmLeases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InvestLands", "OwnerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConfirmInvestments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
