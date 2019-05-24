using System.Threading.Tasks;
using RestaurantsApp.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using MongoDB.Bson;

namespace RestaurantsApp.Services
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
        public async Task<Restaurant> GetById(string id)
        {
            var find = await _restauraunts.FindAsync(_ => _.Id == id);
            var restaurant = await find.FirstOrDefaultAsync();
            return restaurant;
        }

        public async Task<Restaurant[]> GetAllByZipcode(string zipcode)
        {
            var find = await _restauraunts.FindAsync(_ => _.Address.Zipcode == zipcode);
            var list= await find.ToListAsync();
            return list.ToArray();
        }

        public async Task AddGrade(string id, DateTime date, string grade, int score)
        {
            var gradeItem = new GradeItem()
            {
                Date = date,
                Grade = grade,
                Score = score
            };
            var filter = Builders<Restaurant>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Restaurant>.Update.AddToSet(_ => _.Grades, gradeItem);

            await _restauraunts.UpdateOneAsync(filter, update);
        }
    }
}