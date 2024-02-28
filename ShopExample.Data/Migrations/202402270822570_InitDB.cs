namespace ShopExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Logo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ParentID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        UserID = c.String(nullable: false),
                        Subject = c.String(),
                        Message = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Images = c.String(),
                        Videos = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 550),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Url = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Int(nullable: false),
                        GroupID = c.Guid(nullable: false),
                        Target = c.String(nullable: false, maxLength: 10),
                        Static = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
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
                        ID = c.Guid(nullable: false),
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
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Contents = c.String(),
                        Alias = c.String(maxLength: 500, unicode: false),
                        CategoryID = c.Guid(nullable: false),
                        Image = c.String(maxLength: 8000, unicode: false),
                        MoreImage = c.String(storeType: "xml"),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        BuyCount = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        ReviewCount = c.Int(nullable: false),
                        Tags = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Alias = c.String(maxLength: 500),
                        ParentID = c.Guid(),
                        Image = c.String(),
                        DisplayOrder = c.Int(),
                        HomeFlag = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Contents = c.String(maxLength: 501),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Alias = c.String(maxLength: 500),
                        ParentID = c.Guid(),
                        Image = c.String(),
                        DisplayOrder = c.Int(),
                        HomeFlag = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Contents = c.String(),
                        Alias = c.String(maxLength: 500, unicode: false),
                        CategoryID = c.Guid(nullable: false),
                        Image = c.String(),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Guid(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Colors = c.String(),
                        Sizes = c.String(),
                        Rating = c.Int(nullable: false),
                        Brand = c.String(),
                        Material = c.String(),
                        Other_Info = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Guid(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 501),
                        Description = c.String(maxLength: 500),
                        Image = c.String(),
                        Title = c.String(maxLength: 500),
                        DisplayOrder = c.Int(nullable: false),
                        Url = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Guid(nullable: false),
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
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sys_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status_Of = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 500),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 500, unicode: false),
                        MetaKeyWord = c.String(maxLength: 256, unicode: false),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        ValueStr = c.String(maxLength: 500),
                        ValueInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(maxLength: 256),
                        Birthday = c.DateTime(),
                        Fullname = c.String(maxLength: 256),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VisitorStatistic",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroup");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
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
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.Sys_Status");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductDetails");
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
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Errors");
            DropTable("dbo.Brands");
        }
    }
}
