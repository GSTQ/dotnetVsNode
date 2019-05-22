using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetVsNode.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dotnetVsNode.Controllers
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

        // GET api/values
        [HttpGet]
        public Task<string> Get(string id)
        {
            return _restaurantService.GetById(id);
        }
    }
}
