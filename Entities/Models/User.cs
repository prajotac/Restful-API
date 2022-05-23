using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Entities.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string _id { get; set; } = string.Empty;
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("username")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;
        [BsonElement("website")]
        public string Website { get; set; } = string.Empty;
        [BsonElement("company")]
        public Company Company { get; set; }


    }
}
