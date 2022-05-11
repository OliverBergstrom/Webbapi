using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webbapi.Dtos.Restaurang;
using Webbapi.Models;
using Webbapi.Services.RestaurangService;

namespace Webbapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurangController : ControllerBase
    {

        private readonly IRestaurangService _restaurangService;

        public RestaurangController(IRestaurangService restaurangService)
        {
            _restaurangService = restaurangService;

        }

        [HttpGet("GetAll")]
        public ActionResult<List<Restaurang>> Get()
        {
            return Ok(_restaurangService.GetAllRestaurang());
        }

        [HttpGet("{Adress}")]
        public async Task<ActionResult<ServiceResponse<GetRestaurangDto>>> GetSingle(string Adress)
        {
            return Ok(await _restaurangService.GetRestaurangByAdress(Adress));
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<GetRestaurangDto>>>> AddRestaurang(AddRestaurangDto newRestaurang)
        {
            return Ok(await _restaurangService.AddRestaurang(newRestaurang));
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<GetRestaurangDto>>> UpdateRestaurang(UpdateRestaurangDto updateRestaurangDto)
        {
            var response = await _restaurangService.UpdateRestaurang(updateRestaurangDto);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{Adress}")]
        public async Task<ActionResult<ServiceResponse<List<GetRestaurangDto>>>> Delete(string Adress)
        {
            var response = await _restaurangService.DeleteRestaurang(Adress);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}