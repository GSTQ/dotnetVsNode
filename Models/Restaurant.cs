using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantsApp.Models
{
    [BsonIgnoreExtraElements]
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("borough")]
        public string Borough { get; set; }

        [BsonElement("cuisine")]
        public string Cuisine { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("grades")]
        public GradeItem[] Grades { get; set; }
    }
}