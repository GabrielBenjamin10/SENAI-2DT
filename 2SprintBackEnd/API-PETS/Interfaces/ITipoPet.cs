using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface ITipoPet
    {
        //Fazemos os metodos de CRUD e Realizamos uma busca por Id
        //CREATE
        TipoPet Cadastrar(TipoPet t);

        //READ
        List<TipoPet> LerTodos();

        //UPDATE
        TipoPet Alterar(int id, TipoPet t);

        //DELETE
        void Excluir(int id);

        TipoPet BuscarPorId(int id);

    }
}
