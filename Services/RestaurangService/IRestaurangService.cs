using Webbapi.Dtos.Restaurang;
using Webbapi.Models;

namespace Webbapi.Services.RestaurangService
{
    public interface IRestaurangService
    {
        List<Restaurang> GetAllRestaurang();

        Task<ServiceResponse<GetRestaurangDto>> GetRestaurangByAdress(string Adress);

        Task<ServiceResponse<GetRestaurangDto>> AddRestaurang(AddRestaurangDto newRestaurang);

        Task<ServiceResponse<GetRestaurangDto>> UpdateRestaurang(UpdateRestaurangDto updateRestaurang);

        Task<ServiceResponse<List<GetRestaurangDto>>> DeleteRestaurang(string Adress);
    }
}