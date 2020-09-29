using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface IRaca
    {
        //Fazemos os metodos de CRUD e Realizamos uma busca por Id
        //CREATE
        Raca Cadastrar(Raca r);

        //READ
        List<Raca> LerTodos();

        //UPDATE
        Raca Alterar(int id, Raca r);

        //DELETE
        void Excluir(int id);

        Raca BuscarPorId(int id);
    }
}
