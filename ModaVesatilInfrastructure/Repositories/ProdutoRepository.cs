using Dapper;
using ModaVersatilDomain.Interfaces.Repositories;
using ModaVersatilDomain.Models;
using ModaVesatilInfrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVesatilInfrastructure.Repositories
{
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    {
        protected readonly string BaseQuery = @"SELECT  *
                                                FROM    Produtos
                                                WHERE   ATIVO = @Ativo ";

        protected readonly string BaseInsert = @"INSERT INTO Produtos (
                                                        TIPOPRODUTOID,
                                                        DESCRICAO,
                                                        CONTEUDO,
                                                        VALORCOMPRA,
                                                        VALORVENDA,
                                                        QUANTIDADE,
                                                        ATIVO
                                                    ) ";

        protected readonly string BaseUpdate = @"UPDATE Produtos 
                                                SET     TIPOPRODUTOID = @TipoProdutoId,
                                                        DESCRICAO = @Descricao,
                                                        CONTEUDO = @Conteudo,
                                                        VALORCOMPRA = @ValorCompra,
                                                        VALORVENDA = @ValorVenda,
                                                        QUANTIDADE = @Quantidade,
                                                        ATIVO = @Ativo
                                                WHERE   ID = @Id ";

        protected readonly string BaseDelete = @"DELETE FROM Produtos 
                                                WHERE   ID = @Id ";

        public ProdutoRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task AdicionarAsync(Produto produto)
        {
            var query = $"{BaseInsert}" +
                       " VALUES( " +
                       @"   @TipoProdutoId,
                            @Descricao,
                            @Conteudo,
                            @ValorCompra,
                            @ValorVenda,
                            @Quantidade,
                            @Ativo)";

            await Connection.ExecuteAsync(query, produto);
        }

        public async Task AlterarAsync(Produto produto)
        {
            var query = BaseUpdate;

            await Connection.ExecuteAsync(query, produto);
        }

        public async Task ExcluirAsync(int id)
        {
            var query = @"DELETE FROM Produtos WHERE Id = @Id";

            await Connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Produto>> ListarAsync()
        {
            var query = BaseQuery;

            return await Connection.QueryAsync<Produto>(query, new { Ativo = true });
        }

        public async Task<Produto> ObterAsync(int id)
        {
            var query = $"{BaseQuery}" +
                       " AND ID = @Id";

            return await Connection.QueryFirstOrDefaultAsync<Produto>(query, new { Ativo = true, Id = id });
        }
    }
}
