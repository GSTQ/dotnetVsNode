using RestaurantsApp.Models;
using System;
using System.Threading.Tasks;

namespace RestaurantsApp.Services
{
    public interface IRestaurauntService
    {
        Task<Restaurant> GetById(string id);
        Task<Restaurant[]> GetAllByZipcode(string zipcode);
        Task AddGrade(string id, DateTime date, string grade, int score);
    }
}