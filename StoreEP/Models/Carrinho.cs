using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models
{
    public class Carrinho
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Produto produto, int quantidade) {
            CartLine line = lineCollection.Where(p => p.Produto.ProdutoId == produto.ProdutoId).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                line.Quantidade += quantidade;
            }
        }
        public virtual void RemoveLine(Produto produto) => lineCollection.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        public virtual decimal ValorTotal() => lineCollection.Sum(e => e.Produto.Preco * e.Quantidade);
        public virtual void Limpar() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
