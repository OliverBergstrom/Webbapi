
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Webbapi.Dtos.Restaurang;
using Webbapi.Models;

namespace Webbapi.Services.RestaurangService
{
    public class RestaurangService : IRestaurangService
    {

        private static List<Restaurang> restauranger = new List<Restaurang> {
            new Restaurang(),
            new Restaurang {Adress = "Ulfstorg 32",Namn = "Jakobs korvar"}
        };

        

        private readonly IMapper _mapper;
        private readonly DataContext context;

        public RestaurangService(IMapper mapper)
        {
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetRestaurangDto>>> AddRestaurang(AddRestaurangDto newRestaurang)
        {
            var ServiceResponse = new ServiceResponse<List<GetRestaurangDto>>();
            Restaurang restaurang = _mapper.Map<Restaurang>(newRestaurang);
            restaurang.Adress = restauranger.Max(c => c.Adress) + 1;
            restauranger.Add(restaurang);
            ServiceResponse.Data = restauranger.Select(c => _mapper.Map<GetRestaurangDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetRestaurangDto>>> DeleteRestaurang(string Adress)
        {
            var ServiceResponse = new ServiceResponse<List<GetRestaurangDto>>();
            try {
            Restaurang restaurang = restauranger.First(c => c.Adress == Adress);
            restauranger.Remove(restaurang);
            ServiceResponse.Data = restauranger.Select(c => _mapper.Map<GetRestaurangDto>(c)).ToList();
            }
            catch (Exception ex) 
            {
                ServiceResponse.Succes = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }

        public List<Restaurang> GetAllRestaurang()
        {
           return restauranger;
        }

        public async Task<ServiceResponse<GetRestaurangDto>> GetRestaurangByAdress(string Adress)
        {
            var ServiceResponse = new ServiceResponse<GetRestaurangDto>();
            if (Adress == null)
            {
                return null;
            }
            else
            {

                ServiceResponse.Data = _mapper.Map<GetRestaurangDto>(restauranger.FirstOrDefault(c => c.Adress == Adress));
                return ServiceResponse;

            }
        }

        public async Task<ServiceResponse<GetRestaurangDto>> UpdateRestaurang(UpdateRestaurangDto updateRestaurang)
        {
            var ServiceResponse = new ServiceResponse<GetRestaurangDto>();
            try {
            Restaurang restaurang = restauranger.FirstOrDefault(c => c.Adress == updateRestaurang.Adress);

            restaurang.Namn = updateRestaurang.Namn;
            restaurang.Adress = updateRestaurang.Adress;
            restaurang.typ = updateRestaurang.typ;

            ServiceResponse.Data = _mapper.Map<GetRestaurangDto>(restaurang);
            }
            catch (Exception ex) 
            {
                ServiceResponse.Succes = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }

        Task<ServiceResponse<GetRestaurangDto>> IRestaurangService.AddRestaurang(AddRestaurangDto newRestaurang)
        {
            throw new NotImplementedException();
        }

    }
}