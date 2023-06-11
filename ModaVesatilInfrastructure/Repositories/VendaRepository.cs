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
    public class VendaRepository : RepositoryBase, IVendaRepository
    {

        protected readonly string BaseQuery = @"SELECT  *
                                                FROM    Vendas ";

        protected readonly string BaseInsert = @"INSERT INTO Vendas (
                                                        DATACADASTRO,
                                                        TOTAL,
                                                        CODIGORASTREIO,
                                                        CLIENTEID,
                                                        ESTORNADO
                                                    ) ";

        protected readonly string BaseUpdate = @"UPDATE Vendas 
                                                SET     DATACADASTRO = @DataCadastro,
                                                        TOTAL = @Total,
                                                        CODIGORASTREIO = @CodigoRastreio,
                                                        CLIENTEID = @ClienteId,
                                                        ESTORNADO = @Estornado
                                                WHERE   ID = @Id ";

        protected readonly string BaseDelete = @"DELETE FROM Vendas 
                                                WHERE   ID = @Id ";

        public VendaRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task AdicionarAsync(Venda venda)
        {
            var query = $"{BaseInsert}" +
                        " VALUES( " +
                        @"  @DataCadastro,
                            @Total,
                            @CodigoRastreio,
                            @ClienteId,
                            @Estornado)";

            await Connection.ExecuteAsync(query, venda);
        }

        public async Task AlterarAsync(Venda venda)
        {
            var query = BaseUpdate;

            await Connection.ExecuteAsync(query, venda);
        }

        public async Task ExcluirAsync(int id)
        {
            var query = @"DELETE FROM Vendas WHERE Id = @Id";

            await Connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Venda>> ListarAsync()
        {
            var query = BaseQuery;

            return await Connection.QueryAsync<Venda>(query);
        }

        public async Task<IEnumerable<Venda>> ListarPorClienteAsync(int clienteId)
        {
            var query = BaseQuery +
                $" WHERE CLIENTEID = @ClienteId";

            return await Connection.QueryAsync<Venda>(query, new { ClienteId = clienteId });
        }

        public async Task<IEnumerable<Venda>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            var query = BaseQuery +
                        "WHERE DATACADASTRO BETWEEN @DataInicio AND @DataFim";

            return await Connection.QueryAsync<Venda>(query, new { DataInicio = dataInicio, DataFim = dataFim });
        }

        public async Task<Venda> ObterAsync(int id)
        {
            var query = $"{BaseQuery}" +
                       " WHERE ID = @Id";

            return await Connection.QueryFirstOrDefaultAsync<Venda>(query, new { Id = id });
        }
    }
}
