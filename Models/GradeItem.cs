using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RestaurantsApp.Models
{
    [BsonIgnoreExtraElements]
    public class GradeItem
    {
        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("grade")]
        public string Grade { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }
    }
}
