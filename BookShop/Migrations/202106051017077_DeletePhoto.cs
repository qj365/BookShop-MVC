namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePhoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "Photo", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "Photo", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
