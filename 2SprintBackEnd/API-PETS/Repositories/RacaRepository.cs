
using API_Pet.Domains;
using API_Pet.Interfaces;
using API_Pets.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Repositories 
{
    public class RacaRepository : IRaca
    {

        //Chamamos a conexao que foi feita lá no Context
        PetsContext conexao = new PetsContext();

        //Chamamos o objeto que poderá receber e executar os comandos do banco
        SqlCommand cmd = new SqlCommand();


        public Raca Alterar(int id, Raca r)
        {
            // Inicia conexao com a database
            cmd.Connection = conexao.Conectar();

            //Usamos o comando do sql para 
            cmd.CommandText = "UPDATE Raca SET Descricao= @descricao, IdTipoPet = @idtipopet WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);

            //DML --> ExecuteNonQuery
            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            // Usamos o comando de Busca do SQL(WHERE)
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            //Atribuimos as variaves que vem como arg, ou seja, é um tipo de pareamento 
            cmd.Parameters.AddWithValue("@id", id);

            //Damos o play
            SqlDataReader dados = cmd.ExecuteReader();


            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca        = Convert.ToInt32(dados.GetValue(0));
                r.Descricao     = dados.GetValue(1).ToString();
                r.IdTipoPet     = Convert.ToInt32(dados.GetValue(2));
            }


            // Desconectamos o banco
            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            // abri conexao
            cmd.Connection = conexao.Conectar();

            //Aqui nos usamos o comando do sql que vai inserir dados na tabela tipo pet
            cmd.CommandText = "INSERT INTO Raca (Descricao,IdTipoPet)" + "Values" + "(@descricao, @idtipopet)";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);

            //DML --> ExecuteNonQuery
            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();


            conexao.Desconectar();

            return r;
        }

        public void Excluir(int id)
        {
            // Abrir conexao
            cmd.Connection = conexao.Conectar();

            //Casar os seguintes id
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);


            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            //Desconectando
            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            //Abrimos conexao
            cmd.Connection = conexao.Conectar();

            // Usamos o msm comando do banco para consultar a tabela tipopet
            cmd.CommandText = "SELECT * FROM Raca";

            // Precisamos de um play
            SqlDataReader dados = cmd.ExecuteReader();

            // Criamos uma lista para guardar os tipospets
            List<Raca> racas = new List<Raca>();

            //Fazemos uma tratativa com while
            while (dados.Read())
            {
                racas.Add(
                        new Raca()
                        {
                            IdRaca      = Convert.ToInt32(dados.GetValue(0)),
                            Descricao   = dados.GetValue(1).ToString(),
                            IdTipoPet   = Convert.ToInt32(dados.GetValue(2))
                        }
                    );
            }

            //Fechamos conexao
            conexao.Desconectar();

            return racas;
        }
    }
}
