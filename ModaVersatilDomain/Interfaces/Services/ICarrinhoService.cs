﻿using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Services
{
    public interface ICarrinhoService
    {
        Task AdicionarAsync(Carrinho carrinho);
        Task AlterarAsync(Carrinho carrinho);
        Task ExcluirAsync(int clienteId);
        Task ExcluirProdutoAsync(int clienteId, int produtoId);
        Task<Carrinho> ObterAsync(int id);
        Task<IEnumerable<Carrinho>> ListarAsync();
        Task<IEnumerable<Carrinho>> ListarPorClienteAsync(int clienteId);
    }
}
