using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Model
{
    public class Bid
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^.{5,30}$", ErrorMessage = "First Name length should be between 5 to 30 characters")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^.{3,25}$", ErrorMessage = "Last Name length should be between 3 to 25 characters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PIN { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public long BidAmount { get; set; }
    }
}
