using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace dotnetVsNode.Services
{
    public class RestaurauntService : IRestaurauntService
    {
        private readonly IMongoCollection<Restaurant> _restauraunts;

        public RestaurauntService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("RestaurantsDB"));
            var database = client.GetDatabase("test");
            _restauraunts = database.GetCollection<Restaurant>("restaurants");
        }
        public async Task<string> GetById(string id)
        {
            var restaurant = await (await _restauraunts.FindAsync(_ => _.Id == id)).FirstOrDefaultAsync();
            return $"{restaurant.Id} {restaurant.Name}";
        }
    }
}