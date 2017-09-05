using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreEP.Models;

namespace StoreEP.Component
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private readonly StoreEPContext _context;

        public NavigationMenuViewComponent(StoreEPContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_context.Produto.Select(x => x.CategoriaPD).Distinct().OrderBy(x => x));
        }
    }
}
