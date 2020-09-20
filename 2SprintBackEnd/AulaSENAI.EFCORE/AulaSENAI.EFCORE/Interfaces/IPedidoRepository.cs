
using AulaSENAI.EFCORE.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaSENAI.EFCORE.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// adiciona um novo pedido
        /// </summary>
        /// <param name="pedidoItems">itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidoItems);


    }
}