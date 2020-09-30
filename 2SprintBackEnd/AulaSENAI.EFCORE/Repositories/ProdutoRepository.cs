using Api_ORM.Contexts;
using Api_ORM.Domains;
using Api_ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ORM.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura
        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produto.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// busca um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produto.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// busca um produto pelo nome
        /// </summary>
        /// <param name="nome">nome produto</param>
        /// <returns>Retorna produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produto.Where(f => f.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try 
            {
                //Adiciona no objeto ao DbSet
                _ctx.Produto.Add(produto);

                //Salva alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">produto que vai ser alterado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto por id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //verifica se o produto existe
                //caso não existe gera uma exceção
                if(produtoTemp == null)
                {
                   throw new Exception("Produto não encontrado");
                }

                //caso exista, sltera suas propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //altera produto no contexto
                _ctx.Produto.Update(produtoTemp);

                //salva o contexto
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove um produto pelo seu id
        /// </summary>
        /// <param name="id">id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto por id
                Produto produtoTemp = BuscarPorId(id);

                //verifica se o produto existe
                //caso não existe gera uma exceção
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Produto.Remove(produtoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}