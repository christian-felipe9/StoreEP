﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models
{
    public class Pagamento
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int PedidoID { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime CompraDT { get; set; }
        public DateTime? PagamentoDT { get; set; } = null;
    }
}