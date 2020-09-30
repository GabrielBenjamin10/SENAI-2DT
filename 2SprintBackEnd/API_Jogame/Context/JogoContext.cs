using API_Jogame.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Context
{
    public class JogoContext : DbContext
    {
        // sempre colocar o nome no contexto no plural
        // Aqui vai ser onde vamos ccriar a estrutrura das nossas tabelas
        public DbSet<Jogo>          Jogos { get; set; }
        public DbSet<Jogador>       Jogadores { get; set; }
        public DbSet<JogoJogadores>   JogosJogadores { get; set; }

        // Aqui nos fazemos uma sobreposição das config default existentes
        // Usamos uma condicional para configurar e criar o nosso database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source=.\Sqlexpress;Initial Catalog= Jogame;user id=sa; password=sa132");
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
 