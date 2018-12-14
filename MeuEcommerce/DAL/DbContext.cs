using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.DAL
{
    public class DbContext
    {
        static Produto[] _produtos;
        static Categoria[] _categorias;

        public Produto[] GetProdutos()
        {
            if (_produtos == null)
            {
                _produtos = new Models.Produto[]
                {
                    new Models.Produto("Iphone", 1, "smartphones_0", 1),
                    new Models.Produto("Iphone", 1, "smartphones_0", 1),

                    new Models.Produto("TV Led", 2, "TVs_0", 2),
                    new Models.Produto("TV Led", 2, "TVs_0", 2),

                    new Models.Produto("Playstation 4", 3, "Playstation4", 3),
                    new Models.Produto("Playstation 4", 3, "Playstation4", 3),

                    new Models.Produto("Notebook Dell I7", 4, "Notebooks_0", 4),
                    new Models.Produto("Notebook Dell I7", 4, "Notebooks_0", 4),
                };
            }

            return _produtos;
        }

        public Produto GetProdutoPorId(int id)
        {
            var todosOsProdutos = GetProdutos();

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

            return todosOsProdutos.First(item => item.Id == id);
        }

        public Categoria[] GetCategorias()
        {
            if (_categorias == null)
            {
                _categorias = new Models.Categoria[]
                {
                    new Models.Categoria(1, "Smartphones"),
                    new Models.Categoria(2, "TVs"),
                    new Models.Categoria(3, "Video Games"),
                    new Models.Categoria(4, "Notebooks"),
                };
            }

            return _categorias;
        }
    }
}