using API_Jogame.Context;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        // readonly significa somente leitura, sem alterações
        // uso do encapsulamento
        private readonly JogoContext cont;
        // fiz o  metodo construtor para instanciar o context dentro do repository
        public JogoRepository()
        {
            cont = new JogoContext();
        }

        // Region é um comando de organização dos codigos
        #region Gravação

        /// <summary>
        /// Cadastra os jogos
        /// </summary>
        /// <param name="jogo">Objeto jogo</param>
        public Jogo Cadastrar(List<JogoJogadores> jogoJogadores)
        {
            // try - tente
            // catch - excessão
            // Try catch é um tipo de tratativa para o nosso erro
            try
            {
                Jogo jogo = new Jogo
                {
                    Nome = "God of War",
                    Descricao = "God of War é uma série de jogos eletrônicos de ação-aventura vagamente baseado nas mitologias grega e nórdica sendo criado originalmente por David Jaffe da Santa Monica Studio. Iniciada em 2005, a série tornou-se carro-chefe para a marca PlayStation, que consiste em oito jogos em várias plataformas",
                };

                foreach (var item in jogoJogadores)
                {
                    //adiciona um alunoescola a lista
                    jogo.JogosJogadores.Add(new JogoJogadores
                    {

                        IdJogo = jogo.Id,
                        Jogo = item.Jogo,
                        IdJogador = item.IdJogador,
                        Jogador = item.Jogador

                    });
                }
                cont.Jogos.Add(jogo);
                cont.SaveChanges();

                return jogo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um jogo
        /// </summary>
        /// <param name="jogo">jogo a ser editado</param>
        public void Alterar(Jogo jogo)
        {
            try
            {
                //busca jogo pelo id
                Jogo jogoTemp = BuscarPorId(jogo.Id);
                //verifica se o jogo existe no sistema, caso nao exista gera um exception
                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                jogoTemp.Nome = jogo.Nome;
                jogoTemp.Descricao = jogo.Descricao;



                //altera jogo no seu contexto
                cont.Jogos.Update(jogoTemp);
                //salva suas alteraçoes
                cont.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       
        /// <summary>
        /// Exclui o jogo cadastrado
        /// </summary>
        /// <param name="id">ID do jogo</param>
        public void Excluir(Guid id)
        {
            try
            {
                //busca jogo pelo id
                Jogo jogoTemp = BuscarPorId(id);
                //verifica se o jogo existe no sistema, caso nao exista gera um exception
                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove jogo no contexto atual
                cont.Jogos.Remove(jogoTemp);
                //salva as alteraçoes
                cont.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Leitura
        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>Jogo</returns>
        public Jogo BuscarPorId(Guid id)
        {
            {
                try
                {
                    return cont.Jogos
                        .Include(c => c.JogosJogadores)
                        .ThenInclude(c => c.Jogador)
                        .FirstOrDefault(p => p.Id == id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>retorna uma lista de jogos cadastrados</returns>
        public List<Jogo> LerTodos()
        {
            try
            {
                // faz o retorno dessa lista de jogos no contexto
                return cont.Jogos.ToList();
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro vai retornar uma excessao
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Aqui buscamos o jogo pelo seu nome
        /// </summary>
        /// <param name="nome"> nome do jogo</param>
        /// <returns>Jogo</returns>
        public List<Jogo> BuscarPorNome(string nome)
        {
            try
            {
                return cont.Jogos.Where(p => p.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


    }

}
