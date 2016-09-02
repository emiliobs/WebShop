namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wineries", "Foo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wineries", "Foo");
        }
    }
}
