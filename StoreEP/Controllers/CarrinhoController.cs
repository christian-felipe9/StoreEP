using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreEP.Models;
using StoreEP.Infrastructure;
using StoreEP.Models.ViewModels;

namespace StoreEP.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private Carrinho _carrinho;
        public CarrinhoController(
            IProdutoRepositorio produtoRepositorio,
            Carrinho carService)
        {
            _produtoRepositorio = produtoRepositorio;
            _carrinho = carService;
        }
        [HttpGet]
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Carrinho = _carrinho,
                ReturnUrl = returnUrl
            });
        }

        public JsonResult Adicionara(AddCarrinhoViewModel model)
        {
            int quantidade = model.QuantidadeProduto;
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(p => p.ProdutoID == model.ProdutoID);
            if (produto != null)
            {
                int emEstoque = produto.Quantidade;
                _carrinho.AddItem(produto);
            }
            return Json(_carrinho.Lines.Count());

        }
        public RedirectToActionResult RemoverCarrinho(int produtoID, string returnUrl)
        {
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoID);
            if (produto != null)
            {
                _carrinho.RemoveLine(produto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
