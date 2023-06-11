using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AutoMapper
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<TipoProdutoDTORequest, TipoProduto>();
            CreateMap<ProdutoDTORequest, Produto>();
            CreateMap<ClienteDTORequest, Cliente>();
            CreateMap<CarrinhoDTORequest, Carrinho>();
            CreateMap<VendaDTORequest, Venda>();
        }
    }
}
