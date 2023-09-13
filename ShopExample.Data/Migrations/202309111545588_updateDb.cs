namespace ShopExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PromotionPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Warranty", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Warranty", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "PromotionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
