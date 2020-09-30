using Api_ORM.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ORM.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DA6MBAT\SQLEXPRESS;Initial Catalog=curso;User ID=sa;Password=ps132");
        }
    }
}
