using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Model
{
    public class BiddingDatabaseSettings : IBiddingDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ProductCollectionName { get; set; }

        public string BidCollectionName { get; set; }
    }

    public interface IBiddingDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string BidCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
