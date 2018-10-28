﻿using PoC.TesteAutomatizado.Dominio.Entidade;
using System;
using System.Data.SQLite;

namespace PoC.TesteAutomatizado.Repositorio.Mapper
{
    public static class SQLiteDataReaderMapper
    {
        public static Contrato CriarContrato(this SQLiteDataReader consulta)
        {
            return new Contrato()
            {
                ContratoId = int.Parse(consulta["ContratoId"].ToString()),
                VolumeDisponivel = float.Parse(consulta["VolumeDisponivel"].ToString()),
                DataInicioVigencia = new DateTime(long.Parse(consulta["DataInicioVigencia"].ToString())),
                DataFimVigencia = new DateTime(long.Parse(consulta["DataFimVigencia"].ToString())),
                Ativo = (consulta["Ativo"].ToString() == "1")
            };
        }

        public static Pedido CriarPedido(this SQLiteDataReader consulta)
        {
            return new Pedido()
            {
                PedidoId = int.Parse(consulta["PedidoId"].ToString()),
                ContratoId = int.Parse(consulta["ContratoId"].ToString()),
                Volume = float.Parse(consulta["Volume"].ToString()),
                DataPedido = new DateTime(long.Parse(consulta["DataPedido"].ToString()))
            };
        }
    }
}
