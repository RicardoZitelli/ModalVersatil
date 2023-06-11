using ModaVersatilDomain.Interfaces.Repositories;
using ModaVersatilDomain.Models;
using ModaVesatilInfrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ModaVesatilInfrastructure.Repositories
{
    public class TipoProdutoRepository : RepositoryBase, ITipoProdutoRepository
    {
        protected readonly string BaseQuery = @"SELECT  *
                                                FROM    TipoProdutos
                                                WHERE   Ativo = @Ativo ";

        protected readonly string BaseInsert = @"INSERT INTO TipoProdutos (
                                                        DESCRICAO,
                                                        ATIVO
                                                    ) ";

        protected readonly string BaseUpdate = @"UPDATE TipoProdutos 
                                                SET     DESCRICAO = @Descricao,
                                                        ATIVO = @Ativo
                                                WHERE   ID = @Id ";

        protected readonly string BaseDelete = @"DELETE FROM TipoProdutos 
                                                WHERE   ID = @Id ";

        public TipoProdutoRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task AdicionarAsync(TipoProduto tipoProduto)
        {
            var query = $"{BaseInsert}" +
                        " VALUES( " +
                        @"  @Descricao,
                            @Ativo)";

            await Connection.ExecuteAsync(query, tipoProduto);
        }

        public async Task AlterarAsync(TipoProduto tipoProduto)
        {
            var query = BaseUpdate;
            
            await Connection.ExecuteAsync(query, tipoProduto);
        }

        public async Task ExcluirAsync(int id)
        {
            var query = @"DELETE FROM TipoProdutos WHERE Id = @Id";

            await Connection.ExecuteAsync(query,new { Id = id } );
        }

        public async Task<IEnumerable<TipoProduto>> ListarAsync()
        {
            var query = BaseQuery;

            return await Connection.QueryAsync<TipoProduto>(query, new { Ativo = true });
        }
    
        public async Task<TipoProduto> ObterAsync(int id)
        {
            var query = $"{BaseQuery}" +
                        " AND ID = @Id";

            return await Connection.QueryFirstOrDefaultAsync<TipoProduto>(query, new { Ativo = true, Id = id });
        }
    }
}
