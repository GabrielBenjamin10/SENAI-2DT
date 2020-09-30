using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    interface IJogoRepository
    {
        // Aqui fazemos o CRUD
        // Lista todos os jogos cadastrados
        List<Jogo> LerTodos();
        // Neste metodo buscamos por id
        Jogo BuscarPorId(Guid id);
        // Neste metodo buscamos pelo nome
        List<Jogo> BuscarPorNome(string nome);
        // Cadastramos o jogo
        Jogo Cadastrar(List<JogoJogadores> jogoJogadores);
        // Alteramos o jogo
        void Alterar(Jogo jogo);
        // Excluimos o jogo pelo seu Id
        void Excluir(Guid id);
      
        
    }
}
