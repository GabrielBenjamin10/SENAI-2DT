using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        // readonly significa somente leitura, sem alterações
        // uso do encapsulamento
        private readonly PedidoContext cont;
        public ProdutoRepository()
        {
            cont = new PedidoContext();
        }
        // ctor é um atalho para criar um metodo construtor
        // Region é um comando de organização dos codigos
        #region Leitura
        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Produto> LerTodos()
        {
            try
            {
                return cont.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca um produto pelo Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return cont.Produtos.FirstOrDefault(c => c.Id == id);
                return cont.Produtos.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca os produtos pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>retorna um produto</returns>
        public List<Produto> BuscarporNome(string nome)
        {
            try
            {
                // Contains == WHERE
                return cont.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        #endregion

        /// <summary>
        /// ADICIONA UM NOVO PRODUTO
        /// </summary>
        /// <param name="produto">objeto do tipo produto</param>
        #region Gravação
        public void Cadastrar(Produto produto)
        {
            // try - tente
            // catch - excessão
            // Try catch é um tipo de tratativa para o nosso erro
            try
            {
                //Adiciona objeto do tipo produto ao dbset do contexto
                cont.Produtos.Add(produto);
                //_ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Salva as alterações no contexto
                cont.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Edita um prioduto
        /// </summary>
        /// <param name="produto">produto a ser editado</param>
        public void Alterar(Produto produto)
        {
            try
            {
                //Produto prodtuoTemp = cont.Produtos.Find(produto.Id);
                // Buscar produto pelo ID
                Produto produtoTemp = BuscarPorId(produto.Id);

                // verifica se o produto existe
                // Caso não gera um ex
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                // Caso exista altera
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                // Altera os produtos no context
                cont.Produtos.Update(produtoTemp);
                //Salva o contexto
                cont.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">id do produto</param>
        public void Excluir(Guid id)
        {
            try
            {
                //Produto prodtuoTemp = cont.Produtos.Find(produto.Id);
                // Buscar produto pelo ID
                Produto prodtuoTemp = BuscarPorId(id);

                // verifica se o produto existe
                // Caso não gera um ex
                if (prodtuoTemp == null)
                    throw new Exception("Produto não encontrado");

                // Remove os produtos do dbset
                cont.Produtos.Remove(prodtuoTemp);
                // salva as alterações do contexto
                cont.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


    }
}
