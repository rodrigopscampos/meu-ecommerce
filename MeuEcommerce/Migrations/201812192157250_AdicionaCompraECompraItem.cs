namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaCompraECompraItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutoId = c.Int(nullable: false),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.Compra_Id)
                .Index(t => t.ProdutoId)
                .Index(t => t.Compra_Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompraItems", "Compra_Id", "dbo.Compras");
            DropForeignKey("dbo.CompraItems", "ProdutoId", "dbo.Produtos");
            DropIndex("dbo.CompraItems", new[] { "Compra_Id" });
            DropIndex("dbo.CompraItems", new[] { "ProdutoId" });
            DropTable("dbo.Compras");
            DropTable("dbo.CompraItems");
        }
    }
}
