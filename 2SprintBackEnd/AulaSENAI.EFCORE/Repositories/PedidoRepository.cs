using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext cont;

        // Instanciei o meu repositorio
        public PedidoRepository()
        {
            cont = new PedidoContext();
        }
        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return cont.Pedidos
                    // Inner join
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c =>c.Produto)
                    .FirstOrDefault(p =>p.Id == id); 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido Cadastrar(List<PedidoItem> pedidosItens)
        {
            try
            {
                // Criação dos obj do tipo pedido e com a chaves nos permite acessar suas propriedades passando seus valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                    //PedidosItens = new List<PedidoItem>()
                };

                // percorre a lista de pedidosItens e adiciona a lista de pedidositens
                foreach (var item in pedidosItens)
                {
                    //Adiciona um pedidoitem na lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, // Id do obj pedido criado acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    }) ;
                }
                // adiciono o pedido ao meu contexto
                cont.Pedidos.Add(pedido);
                //salva as alterações no contexto no banco de dados
                cont.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> LerTodos()
        {
            try
            {
                return cont.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
