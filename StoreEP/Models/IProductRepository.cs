using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models
{
    public interface IProductRepository 
    {
        IEnumerable<Produto> Produtos { get; }
        void SaveProduct(Produto produto);
        Produto DeleteProduto(int produtoId);
    }
}
