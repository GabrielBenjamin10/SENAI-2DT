using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domains
{
    public class PedidoItem : BaseDomain
    {  
        //Fazer relacionamento da fk
        public Guid IdPedido { get; set; }
        [ForeignKey ("IdPedido")]
        public Pedido Pedido{ get; set; }

        //Fazer relacionamento da fk
        public Guid IdProduto  { get; set; }
        [ForeignKey ("IdProduto")]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        //  Criamos o construtor
    }
}
