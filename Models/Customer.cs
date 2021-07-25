using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Unit_test_sample.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BsonElement("PhoneNumber")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }

    public class CustomerDto{

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}