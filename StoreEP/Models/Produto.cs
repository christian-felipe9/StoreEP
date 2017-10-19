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
        public int ID { get; set; }
        [Required(ErrorMessage = "Escreva um nome válido.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Defina a categoria.")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Estipule um preço.")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Escreva um descrição sobre o produto.")]
        public string Descricao { get; set; }
        //[Required(ErrorMessage = "Digite o link da imagem.")]
        public ICollection<Imagem> Imagens { get; set; }
        //[Required(ErrorMessage = "Quem é o fabricante.")]
        public string Fabricante { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public int Quantidade { get; set; } = 1;
        public bool Publicado { get; set; } = false;
    }
}
