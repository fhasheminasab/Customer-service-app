using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Customer_service_app.Data
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("FirstName")]
		public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}
