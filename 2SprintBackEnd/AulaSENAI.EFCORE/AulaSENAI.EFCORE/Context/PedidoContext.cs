﻿using AulaSENAI.EFCORE.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaSENAI.EFCORE.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BDGHA78\SQLEXPRESS;Initial Catalog = AulaSENAI.EFCORE;User Id = sa; Password = sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
