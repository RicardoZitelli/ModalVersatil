using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
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
            CreateMap<CarrinhoDTOResponse, Carrinho>();
            CreateMap<VendaDTORequest, Venda>();
            
        }
    }
}
