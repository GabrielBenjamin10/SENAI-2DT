using EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    interface IPedidoRepository
    {
        List<Pedido> LerTodos();
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Cadastrar(List<PedidoItem> pedidosItens);
    }
}
    