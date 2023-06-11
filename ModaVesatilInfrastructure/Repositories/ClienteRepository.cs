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
    public class ClienteRepository : RepositoryBase, IClienteRepository
    {
        protected readonly string BaseQuery = @"SELECT  *
                                                FROM    Clientes
                                                WHERE   ATIVO = @Ativo ";

        protected readonly string BaseInsert = @"INSERT INTO Clientes (
                                                        TIPOPRODUTOID,
                                                        DESCRICAO,
                                                        CONTEUDO,
                                                        VALORCOMPRA,
                                                        VALORVENDA,
                                                        QUANTIDADE,
                                                        ATIVO
                                                    ) ";

        protected readonly string BaseUpdate = @"UPDATE Clientes 
                                                SET     NOME = @Nome,
                                                        CPF = @Cpf,
                                                        ENDERECO = @Endereco,
                                                        NUMERO = @Numero,
                                                        CEP = @Cep,
                                                        CIDADE = @Cidade,
                                                        ESTADO = @Estado,
                                                        EMAIL = @Email,
                                                        DATACADASTRO = @DataCadastro,
                                                        USUARIO = @Usuario,
                                                        SENHA = @Senha,                                                        
                                                        ATIVO = @Ativo
                                                WHERE   ID = @Id ";

        protected readonly string BaseDelete = @"DELETE FROM Clientes 
                                                WHERE   ID = @Id ";

        public ClienteRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            var query = $"{BaseInsert}" +
                      " VALUES( " +
                      @"    @Nome,
                            @Cpf,
                            @Endereco,
                            @Numero,
                            @Cep,
                            @Cidade,
                            @Estado,
                            @Email,
                            @DataCadastro,
                            @Usuario,
                            @Senha,                                                        
                            @Ativo)";

            await Connection.ExecuteAsync(query, cliente);
        }

        public async Task AlterarAsync(Cliente cliente)
        {
            var query = BaseUpdate;

            await Connection.ExecuteAsync(query, cliente);
        }

        public async Task ExcluirAsync(int id)
        {
            var query = @"DELETE FROM Clientes WHERE Id = @Id";

            await Connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Cliente>> ListarAsync()
        {
            var query = BaseQuery;

            return await Connection.QueryAsync<Cliente>(query, new { Ativo = true });
        }

        public async Task<Cliente> ObterAsync(int id)
        {
            var query = $"{BaseQuery}" +
                         " AND ID = @Id";

            return await Connection.QueryFirstOrDefaultAsync<Cliente>(query, new { Ativo = true, Id = id });
        }
    }
}
