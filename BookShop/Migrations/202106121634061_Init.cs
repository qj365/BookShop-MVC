namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "Photo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Banner", "Photo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Banner", "RefLink", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banner", "RefLink", c => c.String(maxLength: 255));
            AlterColumn("dbo.Banner", "Photo", c => c.String(maxLength: 255));
            AlterColumn("dbo.Book", "Photo", c => c.String(maxLength: 500));
        }
    }
}
