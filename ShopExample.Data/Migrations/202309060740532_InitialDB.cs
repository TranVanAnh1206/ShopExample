namespace ShopExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 550),
                        Contents = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroup",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 550),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Url = c.String(nullable: false, maxLength: 256, unicode: false),
                        DisplayOrder = c.Int(nullable: false),
                        GroupID = c.Long(nullable: false),
                        Target = c.String(nullable: false, maxLength: 10, unicode: false),
                        Static = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 501),
                        CustomerAddress = c.String(nullable: false, maxLength: 501),
                        CustomerPhone = c.String(nullable: false, maxLength: 20),
                        CustomerEmail = c.String(maxLength: 501),
                        CustomerMessage = c.String(maxLength: 501),
                        PaymentMethod = c.String(nullable: false, maxLength: 256),
                        PaymentStatus = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Contents = c.String(),
                        Alias = c.String(maxLength: 500, unicode: false),
                        CategoryID = c.Long(nullable: false),
                        Image = c.String(maxLength: 256, unicode: false),
                        MoreImage = c.String(storeType: "xml"),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        BuyCount = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Warranty = c.Int(nullable: false),
                        ReviewCount = c.Int(nullable: false),
                        Origin = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Alias = c.String(maxLength: 500, unicode: false),
                        ParentID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256, unicode: false),
                        DisplayOrder = c.Int(nullable: false),
                        HomeFlag = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Contents = c.String(maxLength: 501),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Alias = c.String(maxLength: 500, unicode: false),
                        ParentID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256, unicode: false),
                        DisplayOrder = c.Int(nullable: false),
                        HomeFlag = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Contents = c.String(),
                        Alias = c.String(maxLength: 500, unicode: false),
                        CategoryID = c.Long(nullable: false),
                        Image = c.String(maxLength: 256, unicode: false),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 256, unicode: false),
                        Title = c.String(maxLength: 500),
                        DisplayOrder = c.Int(nullable: false),
                        Url = c.String(maxLength: 256, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Department = c.String(nullable: false, maxLength: 255),
                        Skype = c.String(maxLength: 255),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(maxLength: 255),
                        Facebook = c.String(maxLength: 255),
                        Twitter = c.String(maxLength: 255),
                        Instagram = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ValueStr = c.String(maxLength: 500),
                        ValueInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistic",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroup");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropTable("dbo.VisitorStatistic");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroup");
            DropTable("dbo.Footers");
        }
    }
}
