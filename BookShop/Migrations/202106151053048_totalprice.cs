namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailOrder", "Price", c => c.Int());
            AddColumn("dbo.DetailOrder", "TotalPrice", c => c.Int());
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int());
            AlterColumn("dbo.Book", "Photo", c => c.String(maxLength: 500));
            AlterColumn("dbo.Banner", "Photo", c => c.String(maxLength: 255));
            AlterColumn("dbo.Banner", "RefLink", c => c.String(maxLength: 255));
            DropColumn("dbo.DetailOrder", "TotalAmount");
            DropColumn("dbo.Orders", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalAmount", c => c.Int());
            AddColumn("dbo.DetailOrder", "TotalAmount", c => c.Int());
            AlterColumn("dbo.Banner", "RefLink", c => c.String(maxLength: 50));
            AlterColumn("dbo.Banner", "Photo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Book", "Photo", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.DetailOrder", "TotalPrice");
            DropColumn("dbo.DetailOrder", "Price");
        }
    }
}
