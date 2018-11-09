namespace StorageManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB21 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Transactions", "ProductId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
        }
    }
}
