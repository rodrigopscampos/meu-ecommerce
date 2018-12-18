namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustaChaveEstrangeira : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            RenameColumn(table: "dbo.Produtoes", name: "Categoria_Id", newName: "CategoriaId");
            AlterColumn("dbo.Produtoes", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            DropColumn("dbo.Produtoes", "IdCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "IdCategoria", c => c.Int(nullable: false));
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            AlterColumn("dbo.Produtoes", "CategoriaId", c => c.Int());
            RenameColumn(table: "dbo.Produtoes", name: "CategoriaId", newName: "Categoria_Id");
            CreateIndex("dbo.Produtoes", "Categoria_Id");
            AddForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias", "Id");
        }
    }
}
