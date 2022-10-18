using MongoDB.Driver;
using SellerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Services
{
    public class BiddingService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Bid> _bids;

        public BiddingService(IBiddingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
            _bids = database.GetCollection<Bid>(settings.BidCollectionName);
        }

        public List<Product> GetProducts() =>
            _products.Find(product => true).ToList();

        public Product GetProduct(string id) =>
            _products.Find<Product>(product => product.Id == id).FirstOrDefault();

        public Product CreateProduct(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void UpdateProduct(string id, Product productIn) =>
            _products.ReplaceOne(product => product.Id == id, productIn);

        public void RemoveProduct(Product productIn) =>
            _products.DeleteOne(product => product.Id == productIn.Id);

        public void RemoveProduct(string id) =>
            _products.DeleteOne(product => product.Id == id);

        public List<Bid> GetBids(string productId) =>
            _bids.Find(bid => bid.ProductId == productId).ToList();

        public Bid GetBid(string id) =>
            _bids.Find<Bid>(bid => bid.Id == id).FirstOrDefault();

        public Bid CreateBid(Bid bid)
        {
            _bids.InsertOne(bid);
            return bid;
        }

        public void UpdateBid(string id, Bid bidIn) =>
            _bids.ReplaceOne(bid => bid.Id == id, bidIn);

        public void RemoveBid(Bid bidIn) =>
            _bids.DeleteOne(bid => bid.Id == bidIn.Id);

        public void RemoveBid(string id) =>
            _bids.DeleteOne(bid => bid.Id == id);
    }
}
