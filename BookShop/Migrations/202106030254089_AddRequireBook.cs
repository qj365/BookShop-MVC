namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequireBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "IdAuthor", "dbo.Author");
            DropForeignKey("dbo.Book", "IdCategory", "dbo.Category");
            DropForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "IdPublisher" });
            DropIndex("dbo.Book", new[] { "IdCategory" });
            DropIndex("dbo.Book", new[] { "IdAuthor" });
            AlterColumn("dbo.Book", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Book", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Photo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Book", "IdPublisher", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "IdCategory", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "IdAuthor", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "IdPublisher");
            CreateIndex("dbo.Book", "IdCategory");
            CreateIndex("dbo.Book", "IdAuthor");
            AddForeignKey("dbo.Book", "IdAuthor", "dbo.Author", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Book", "IdCategory", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.Book", "IdCategory", "dbo.Category");
            DropForeignKey("dbo.Book", "IdAuthor", "dbo.Author");
            DropIndex("dbo.Book", new[] { "IdAuthor" });
            DropIndex("dbo.Book", new[] { "IdCategory" });
            DropIndex("dbo.Book", new[] { "IdPublisher" });
            AlterColumn("dbo.Book", "IdAuthor", c => c.Int());
            AlterColumn("dbo.Book", "IdCategory", c => c.Int());
            AlterColumn("dbo.Book", "IdPublisher", c => c.Int());
            AlterColumn("dbo.Book", "Photo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Book", "Amount", c => c.Int());
            AlterColumn("dbo.Book", "Price", c => c.Int());
            AlterColumn("dbo.Book", "Discount", c => c.Double());
            AlterColumn("dbo.Book", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Book", "IdAuthor");
            CreateIndex("dbo.Book", "IdCategory");
            CreateIndex("dbo.Book", "IdPublisher");
            AddForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher", "Id");
            AddForeignKey("dbo.Book", "IdCategory", "dbo.Category", "Id");
            AddForeignKey("dbo.Book", "IdAuthor", "dbo.Author", "Id");
        }
    }
}
