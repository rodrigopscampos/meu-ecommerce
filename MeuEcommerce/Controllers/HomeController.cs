using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? categoria)
        {
            var model = new Models.HomeIndexViewModel();
            model.CategoriaSelectionada = categoria;
        
            model.Produtos = new Models.Produto[]
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

            model.Categorias = new Models.Categoria[]
            {
                new Models.Categoria(1, "Smartphones"),
                new Models.Categoria(2, "TVs"),
                new Models.Categoria(3, "Video Games"),
                new Models.Categoria(4, "Notebooks"),
            };

            if(categoria != null)
            {
                model.Produtos = model.Produtos
                    .Where(p => p.IdCategoria == categoria)
                    .ToArray();

            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}