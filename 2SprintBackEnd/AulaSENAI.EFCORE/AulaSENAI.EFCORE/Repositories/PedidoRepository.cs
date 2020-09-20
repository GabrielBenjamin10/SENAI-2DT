﻿using AulaSENAI.EFCORE.Context;
using AulaSENAI.EFCORE.Domains;
using AulaSENAI.EFCORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaSENAI.EFCORE.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;
        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidoItems)
        {
            try
            {
                // criando objeto pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido efetuado",
                    OrderDate = DateTime.Now,
                    PedidoItem = new List<PedidoItem>()
                };

                //percorre a lista de pedidoItems e adiciona a lista de pedidosItems
                foreach (var item in pedidoItems)
                {
                    // adiciona um pedidoItem
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //id do objeto acabou de ser criado acima
                        IdProduto = item.Id,
                        Quantidade = item.Quantidade
                    });
                }

                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();

                return pedido;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.Include(f => f.PedidoItem).ThenInclude(d => d.Produto).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}