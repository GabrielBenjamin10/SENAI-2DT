using API_Jogame.Context;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly JogoContext cont;
        public JogadorRepository()
        {
            cont = new JogoContext();
        }

        /// <summary>
        /// Metodo para cadastrar jogadores  retornando uma lista de jogosjogadores
        /// </summary>
        /// <param name="JogosJogadores">Jogos dos jogadores</param>
        /// <returns>jogadores</returns>
        public void Cadastrar(Jogador jogador)
        {
            try
            {

                //adiciona o objeto no contexto
                cont.Jogadores.Add(jogador);
                //salva as alteracoes
                cont.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// busca um jogador por id
        /// </summary>
        /// <param name="id"> busca pelo id</param>
        /// <returns>mostra o jogador</returns>
        public Jogador BuscarPorId(Guid id)
        {
            try
            {
                return cont.Jogadores.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Aqui buscamos o jogador pelo seu nome
        /// </summary>
        /// <param name="nome">Nome do jogador</param>
        /// <returns>Jogador</returns>
        public List<Jogador> BuscarPorNome(string nome)
        {
            try
            {
                return cont.Jogadores.Where(p => p.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Altera o jogador 
        /// </summary>
        /// <param name="jogador">o jogador alterado</param>
        public void Alterar(Jogador jogador)
        {
            try
            {
                //busca jogador pelo id
                Jogador jogadorTemp = BuscarPorId(jogador.Id);
                //verifica se o jogador existe no sistema, caso nao exista gera um exception
                if (jogadorTemp == null)
                    throw new Exception("O Jogador procurado não foi encontrado em seu banco. Verifique se foi escrito corretamente");

                //caso exista altera suas propriedades
                jogadorTemp.Nome = jogador.Nome;
                jogadorTemp.Email = jogador.Email;
                //questao de seguranca
                jogadorTemp.Senha = jogador.Senha;
                jogadorTemp.DataNascimento = jogador.DataNascimento;



                //altera jogador no seu contexto
                cont.Jogadores.Update(jogadorTemp);
                //salva suas alteraçoes
                cont.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os jogadores cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Jogador> LerTodos()
        {
            try
            {
                return cont.Jogadores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Exclui os jogadores cadastrados
        /// </summary>
        /// <param name="id">Id dos jogadores</param>
        public void Excluir(Guid id)
        {
            try
            {
                //busca jogador pelo id
                Jogador jogadorTemp = BuscarPorId(id);
                //verifica se o jogador existe no sistema, caso nao exista gera um exception
                if (jogadorTemp == null)
                    throw new Exception("O Jogador procurado não foi encontrado em seu banco. Verifique se foi escrito corretamente");

                //remove jogador no contexto atual
               cont.Jogadores.Remove(jogadorTemp);
                //salva as alteraçoes
                cont.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
