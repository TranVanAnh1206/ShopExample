namespace ShopExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCollumm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"));
            AlterColumn("dbo.Products", "HomeFlag", c => c.Boolean(nullable: false, defaultValue: true));
            AlterColumn("dbo.Products", "HotFlag", c => c.Boolean(nullable: false, defaultValue: false));
            AlterColumn("dbo.Products", "ViewCount", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.Products", "BuyCount", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.Products", "ReviewCount", c => c.Int(nullable: false, defaultValue: 0));

            AlterColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"));
            AlterColumn("dbo.PostCategories", "HomeFlag", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
        }
    }
}
