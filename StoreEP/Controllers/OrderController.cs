﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreEP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEP.Controllers
{
    
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            this.repository = repoService;
            this.cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (order.Lines?.Count() == 0)
            {
                ModelState.AddModelError("", "Descupe sua lista está vazia.");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
