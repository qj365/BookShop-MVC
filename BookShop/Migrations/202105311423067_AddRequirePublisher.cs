namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequirePublisher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publisher", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publisher", "Name", c => c.String(maxLength: 50));
        }
    }
}
