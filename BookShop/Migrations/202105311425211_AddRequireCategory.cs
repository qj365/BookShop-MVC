namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequireCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Author", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Author", "Name", c => c.String(maxLength: 50));
        }
    }
}
