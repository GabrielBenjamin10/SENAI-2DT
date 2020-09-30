using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    public class JogoJogadores : BaseDomain
    {
        // Fazemos o relacionamento da FK(IdJogo)
        public Guid IdJogo { get; set; }

        [ForeignKey("IdJogo")]

        public Jogo Jogo { get; set; }

        // Fazemos o relacionamento da FK(IdJogador)

        public Guid IdJogador { get; set; }


        [ForeignKey("IdJogador")]

        public Jogador Jogador { get; set; }

        [Required]
        public int Quantidade { get; set; }


    }
}
