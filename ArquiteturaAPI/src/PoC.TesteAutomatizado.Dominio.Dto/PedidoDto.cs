﻿using System;

namespace PoC.TesteAutomatizado.Dominio.Dto
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }
        public int ContratoId { get; set; }
        public float Volume { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
