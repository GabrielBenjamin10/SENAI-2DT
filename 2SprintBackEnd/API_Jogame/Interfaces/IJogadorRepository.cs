using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    interface IJogadorRepository
    {
        List<Jogador> LerTodos();
        Jogador BuscarPorId(Guid id);
        List<Jogador> BuscarPorNome(string nome);
        void Cadastrar(Jogador jogador);
        void Alterar(Jogador jogador);
        void Excluir(Guid id);

    }
}
