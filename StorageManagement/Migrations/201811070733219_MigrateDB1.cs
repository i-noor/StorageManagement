namespace StorageManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Operation", c => c.String());
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Transactions", "Cost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Cost", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Operation");
        }
    }
}
