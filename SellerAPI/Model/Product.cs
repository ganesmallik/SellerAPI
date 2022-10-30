using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Model
{
    [DynamoDBTable("products")]
    public class Product
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^.{5,30}$",ErrorMessage = "Product Name length should be between 5 to 30 characters")]
        [DynamoDBProperty("name")]
        public string ProductName { get; set; }
        [DynamoDBProperty("shortDescription")]
        public string ShortDescription { get; set; }
        [DynamoDBProperty("description")]
        public string Description { get; set; }
        [DynamoDBProperty("category")]
        public string Category { get; set; }
        [DynamoDBProperty("startingPrice")]
        [Required]
        public long StartingPrice { get; set; }
        [DynamoDBProperty("endDate")]
        [Required]
        public DateTime EndDate { get; set; }


        //Seller Section
        [DynamoDBProperty("firstName")]
        [Required]
        [RegularExpression("^.{5,30}$", ErrorMessage = "First Name length should be between 5 to 30 characters")]
        public string FirstName { get; set; }
        [DynamoDBProperty("lastName")]
        [Required]
        [RegularExpression("^.{3,25}$", ErrorMessage = "Last Name length should be between 3 to 25 characters")]
        public string LastName { get; set; }
        [DynamoDBProperty("address")]
        public string Address { get; set; }
        [DynamoDBProperty("city")]
        public string City { get; set; }
        [DynamoDBProperty("state")]
        public string State { get; set; }
        [DynamoDBProperty("pin")]
        public string PIN { get; set; }
        [DynamoDBProperty("phone")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }
        [DynamoDBProperty("email")]
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
