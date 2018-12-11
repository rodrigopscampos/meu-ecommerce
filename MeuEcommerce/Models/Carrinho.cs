using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Carrinho
    {
        private Dictionary<int, CarrinhoItem> Itens;

        public Carrinho()
        {
            Itens = new Dictionary<int, CarrinhoItem>();
        }

        public void Add(Produto produto)
        {
            if(Itens.ContainsKey(produto.Id))
            {
                Itens[produto.Id].Quantidade++;
            }
            else
            {
                var carrinhoItem = new CarrinhoItem(
                    produto.Id,
                    produto.Nome,
                    produto.Preco);

                Itens.Add(produto.Id, carrinhoItem);
            }
        }

        public int QuantidadeDeItens => Itens.Values.Sum(item => item.Quantidade);
    }

    public class CarrinhoItem
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public CarrinhoItem(
            int idProduto, 
            string nome, 
            decimal precoUnitario)
        {
            this.IdProduto = idProduto;
            this.Nome = nome;
            this.Quantidade = 1;
            this.PrecoUnitario = precoUnitario;
        }

        public decimal PrecoTotal 
            => PrecoUnitario * Quantidade;
    }
}