﻿using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;

namespace ModaVersatilApplication.Interfaces
{
    public interface ICarrinhoAppService
    {
        Task AdicionarAsync(CarrinhoDTORequest carrinho);
        Task AlterarAsync(CarrinhoDTORequest carrinho);
        Task ExcluirAsync(int id);
        Task<CarrinhoDTOResponse> ObterAsync(int id);
        Task<IEnumerable<CarrinhoDTOResponse>> ListarAsync();
    }
}
