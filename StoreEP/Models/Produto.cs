using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }
        [Required(ErrorMessage = "Escreva um nome válido.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Apenas caractéres.")]
        public string NomePD { get; set; }
        [Required(ErrorMessage = "Defina a categoria.")]
        public string CategoriaPD { get; set; }
        [Required(ErrorMessage = "Estipule um preço.")]
        public decimal PrecoPD { get; set; }
        [Required(ErrorMessage = "Escreva um descrição sobre o produto.")]
        public string DescricaoPD { get; set; }
        //[Required(ErrorMessage = "Digite o link da imagem.")]
        public IEnumerable<Imagem> Imagens { get; set; }
        //[Required(ErrorMessage = "Quem é o fabricante.")]
        public string Fabricante { get; set; }
        public Comentario Comentario { get; set; }
    }
}
