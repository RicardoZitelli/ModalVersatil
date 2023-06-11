﻿using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.Services
{
    public interface ITipoProdutoService
    {
        Task AdicionarAsync(TipoProduto tipoProduto);
        Task AlterarAsync(TipoProduto tipoProduto);
        Task ExcluirAsync(int id);
        Task<TipoProduto> ObterAsync(int id);
        Task<IEnumerable<TipoProduto>> ListarAsync();

    }
}
