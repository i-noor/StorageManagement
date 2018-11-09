namespace StorageManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int(nullable: false));
        }
    }
}
