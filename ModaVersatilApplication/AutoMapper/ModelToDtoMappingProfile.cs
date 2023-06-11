using AutoMapper;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AutoMapper
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<TipoProduto, TipoProdutoDTOResponse>();
            CreateMap<Produto, ProdutoDTOResponse>();
            CreateMap<Cliente, ClienteDTOResponse>();
            CreateMap<Carrinho, CarrinhoDTOResponse>();
            CreateMap<Venda, VendaDTOResponse>();
        }

    }
}
