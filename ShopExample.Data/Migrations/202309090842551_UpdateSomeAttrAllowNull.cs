namespace ShopExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSomeAttrAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "ParentID", c => c.Int());
            AlterColumn("dbo.ProductCategories", "DisplayOrder", c => c.Int());
            AlterColumn("dbo.PostCategories", "ParentID", c => c.Int());
            AlterColumn("dbo.PostCategories", "DisplayOrder", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostCategories", "DisplayOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategories", "ParentID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "DisplayOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "ParentID", c => c.Int(nullable: false));
        }
    }
}
