namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wineries", "Foo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wineries", "Foo", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
