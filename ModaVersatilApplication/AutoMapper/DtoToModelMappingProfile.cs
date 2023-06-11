using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilApplication.AutoMapper
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<TipoProdutoDTORequest, TipoProduto>();
        }
    }
}
