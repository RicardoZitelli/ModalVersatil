﻿using Dapper;
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
    public class CarrinhoRepository : RepositoryBase, ICarrinhoRepository
    {

        protected readonly string BaseQuery = @"SELECT  *
                                                FROM    Carrinhos ";

        protected readonly string BaseInsert = @"INSERT INTO Carrinhos (
                                                        ClienteId,
                                                        ProdutoId,
                                                        Quantidade,
                                                        ValorVenda,
                                                        Total,
                                                        DataCadastro,
                                                        VendaId,
                                                        ClienteTemporarioId
                                                    ) ";

        protected readonly string BaseUpdate = @"UPDATE Carrinhos 
                                                SET     CLIENTEID = @ClienteId,
                                                        PRODUTOID = @ProdutoId,
                                                        QUANTIDADE = @Quantidade,
                                                        VALORVENDA = @ValorVenda,
                                                        TOTAL = @Total,
                                                        DATACADASTRO = @DataCadastro,
                                                        VENDAID = @VendaId,
                                                        CLIENTETEMPORARIOID = @ClienteTemporarioId
                                                WHERE   ID = @Id ";

        protected readonly string BaseDelete = @"DELETE FROM Carrinhos 
                                                WHERE   ID = @Id ";

        public CarrinhoRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task AdicionarAsync(Carrinho carrinho)
        {
            var query = $"{BaseInsert}" +
                       " VALUES( " +
                       @"   @ClienteId,
                            @ProdutoId,
                            @Quantidade,
                            @ValorVenda,
                            @Total,
                            @DataCadastro,
                            @VendaId,
                            @ClienteTemporarioId)";

            await Connection.ExecuteAsync(query, carrinho);
        }

        public async Task AlterarAsync(Carrinho carrinho)
        {
            var query = BaseUpdate;

            await Connection.ExecuteAsync(query, carrinho);
        }

        public async Task ExcluirAsync(int id)
        {
            var query = @"DELETE FROM Clientes WHERE Id = @Id";

            await Connection.ExecuteAsync(query, id);
        }

        public async Task<IEnumerable<Carrinho>> ListarAsync()
        {
            var query = BaseQuery;

            return await Connection.QueryAsync<Carrinho>(query);
        }

        public async Task<Carrinho> ObterAsync(int id)
        {
            var query = $"{BaseQuery}" +
                        " WHERE ID = @Id";

            return await Connection.QueryFirstOrDefaultAsync<Carrinho>(query, new { Id = id });
        }

        public async Task<IEnumerable<Carrinho>> ListarPorClienteIdAsync(int clienteId)
        {
            var query = $"{BaseQuery}" +
                        " WHERE CLIENTEID = @ClienteId";

            return await Connection.QueryAsync<Carrinho>(query, new { ClienteId = clienteId });
        }
    }
}
