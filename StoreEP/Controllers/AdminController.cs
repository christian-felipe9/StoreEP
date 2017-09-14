using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreEP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEP.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Produtos);

        [AutoValidateAntiforgeryToken]
        public ViewResult Edit(int batata) => View(repository.Produtos.FirstOrDefault(p => p.ProdutoID == batata));

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(produto);
                TempData["massage"] = $"{produto.NomePD} foi salvo com sucesso.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(produto);
            }
        }
        public ViewResult Create() => View("Edit", new Produto());
        [HttpPost]
        public IActionResult Delete(int produtoId)
        {
            Produto deletedProduto = repository.DeleteProduto(produtoId);
            if (deletedProduto != null)
            {
                TempData["message"] = $"{deletedProduto.NomePD} foi apagado." ;
            }
            return RedirectToAction("Index");
        }
    }
}
