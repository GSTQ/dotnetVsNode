using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dotnetVsNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new MongoClient("mongodb://192.168.99.100:27017");
            Console.WriteLine("connected");
            var database = client.GetDatabase("test");
            Console.WriteLine("Get db");
            var colls = database.GetCollection<Restaurant>("restaurants");
            Console.WriteLine("Get collection");
            var doc = await colls.CountAsync(_ => _.Id == "5ce2dba31e1a056d00948036");
            //Console.WriteLine("Find");
            //var r = await doc.FirstOrDefaultAsync();
            return $"{doc}";
        }
    }
}
