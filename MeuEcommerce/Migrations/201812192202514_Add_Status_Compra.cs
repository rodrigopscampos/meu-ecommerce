namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Status_Compra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compras", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compras", "Status");
        }
    }
}
