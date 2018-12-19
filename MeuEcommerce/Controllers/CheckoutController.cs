using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        public ActionResult Index()
        {
            var model = new CheckoutIndexViewModel();
            model.Carrinho = GetCarrinho();

            return View(model);
        }

        public ActionResult Continuar()
        {
            return View();
        }

        public ActionResult Incrementa(int id)
        {
            var carrinho = GetCarrinho();
            carrinho.Incrementa(id);

            return RedirectToAction("Index");
        }

        public ActionResult Decrementa(int id)
        {
            var carrinho = GetCarrinho();
            carrinho.Decrementa(id);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var carrinho = GetCarrinho();
            carrinho.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Limpar()
        {
            var carrinho = GetCarrinho();
            carrinho.Limpar();

            return RedirectToAction(
                actionName: "Index", 
                controllerName: "Home");
        }

        public ActionResult CompraRealizada()
        {
            var carrinho = GetCarrinho();

            var compraItens = new List<CompraItem>();

            foreach (var item in carrinho.Itens)
            {
                compraItens.Add(
                    new CompraItem(
                        item.Value.Quantidade,
                        item.Value.PrecoUnitario,
                        item.Value.IdProduto));
            }

            var compra = new Compra(compraItens);
            _dal.Compras.Add(compra);
            _dal.SaveChanges();

            return View();
        }
    }
}