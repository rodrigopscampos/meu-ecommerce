using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeuEcommerce.DAL
{
    public class Database : DbContext
    {
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<Produto> Produtos { get; set; }

        public IDbSet<Compra> Compras { get; set; }
        public IDbSet<CompraItem> CompraItens { get; set; }

        public Produto GetProdutoPorId(int id)
        {
            /*
            foreach (var item in todosOsProdutos)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
            */

            return Produtos.First(item => item.Id == id);
        }
    }
}