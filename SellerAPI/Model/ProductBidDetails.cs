using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Model
{
    public class ProductBidDetails
    {
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public long StartingPrice { get; set; }
        public DateTime EndDate { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
