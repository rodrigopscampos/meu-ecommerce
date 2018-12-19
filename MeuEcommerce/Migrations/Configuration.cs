namespace MeuEcommerce.Migrations
{
    using MeuEcommerce.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeuEcommerce.DAL.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MeuEcommerce.DAL.Database";
        }

        protected override void Seed(MeuEcommerce.DAL.Database context)
        {
            context.Categorias.AddOrUpdate(
                new Categoria(1, "Tvs"),
                new Categoria(2, "Notebooks"),
                new Categoria(3, "Video Games"),
                new Categoria(4, "Smartphones")
                );

            context.Produtos.AddOrUpdate(
                new Produto("Tv 1", 1),
                new Produto("Tv 1", 1),

                new Produto("Notebook 1", 2),
                new Produto("Notebook 1", 2),

                new Produto("Vide Game 1", 3),
                new Produto("Vide Game 1", 3),

                new Produto("Smartphone 1", 4),
                new Produto("Smartphone 2", 4)
                );

            context.SaveChanges();
        }
    }
}
