﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreEP.Models.Interface
{
    public interface IPagamentoRepositorio
    {
        IEnumerable<Pedido> Pedidos { get; set; }
    }
}
