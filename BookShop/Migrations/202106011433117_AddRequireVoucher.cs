namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequireVoucher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voucher", "Discount", c => c.Double(nullable: false));
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Voucher", "Discount", c => c.Double());
        }
    }
}
