using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public int ProdutoID { get; set; }
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; }
    }
}
