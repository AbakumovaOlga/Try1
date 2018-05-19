namespace SweetShopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bakers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BakerFIO = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Requests",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    CakeId = c.Int(nullable: false),
                    BakerId = c.Int(),
                    Count = c.Int(nullable: false),
                    Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.Int(nullable: false),
                    DateCreate = c.DateTime(nullable: false),
                    DateBaking = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bakers", t => t.BakerId)
                .ForeignKey("dbo.Cakes", t => t.CakeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CakeId)
                .Index(t => t.BakerId);

            CreateTable(
                "dbo.Cakes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CakeName = c.String(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CakeIngredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CakeId = c.Int(nullable: false),
                    IngredientId = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cakes", t => t.CakeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.CakeId)
                .Index(t => t.IngredientId);

            CreateTable(
                "dbo.Ingredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IngredientName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.FridgeIngredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FridgeId = c.Int(nullable: false),
                    IngredientId = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fridges", t => t.FridgeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.FridgeId)
                .Index(t => t.IngredientId);

            CreateTable(
                "dbo.Fridges",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FridgeName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerFIO = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Requests", "CakeId", "dbo.Cakes");
            DropForeignKey("dbo.FridgeIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.FridgeIngredients", "FridgeId", "dbo.Fridges");
            DropForeignKey("dbo.CakeIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.CakeIngredients", "CakeId", "dbo.Cakes");
            DropForeignKey("dbo.Requests", "BakerId", "dbo.Bakers");
            DropIndex("dbo.FridgeIngredients", new[] { "IngredientId" });
            DropIndex("dbo.FridgeIngredients", new[] { "FridgeId" });
            DropIndex("dbo.CakeIngredients", new[] { "IngredientId" });
            DropIndex("dbo.CakeIngredients", new[] { "CakeId" });
            DropIndex("dbo.Requests", new[] { "BakerId" });
            DropIndex("dbo.Requests", new[] { "CakeId" });
            DropIndex("dbo.Requests", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Fridges");
            DropTable("dbo.FridgeIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.CakeIngredients");
            DropTable("dbo.Cakes");
            DropTable("dbo.Requests");
            DropTable("dbo.Bakers");
        }
    }
}
