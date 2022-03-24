using AutoMapper;
using Webbapi.Dtos.Restaurang;
using Webbapi.Models;

namespace Webbapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Restaurang, GetRestaurangDto>();
            CreateMap<AddRestaurangDto, Restaurang>();
        }
    }
}