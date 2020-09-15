using AulaSENAI.EFCORE.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaSENAI.EFCORE.Interfaces
{
    interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        void Adicionar(Produto produto);
        List<Produto> BuscarPorNome(string nome);
        void Editar(Produto produto);
        void Remover(Guid id);

    }
}
