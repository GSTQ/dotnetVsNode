using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantsApp.Models;
using RestaurantsApp.Services;

namespace RestaurantsApp.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurauntService _restaurantService;

        public RestaurantController(IRestaurauntService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public Task<Restaurant> Get(string id)
        {
            return _restaurantService.GetById(id);
        }

        [HttpGet("list")]
        public Task<Restaurant[]> GetList(string zipcode)
        {
            return _restaurantService.GetAllByZipcode(zipcode);
        }

        [HttpPut("{id}/grade")]
        public Task AddGrade([FromRoute] string id, DateTime date, string grade, int score)
        {
            return _restaurantService.AddGrade(id, date, grade, score);
        }
    }
}
