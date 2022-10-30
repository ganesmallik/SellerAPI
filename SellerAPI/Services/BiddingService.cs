using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SellerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Services
{
    public class BiddingService : IBiddingService
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public BiddingService(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task<List<Product>> GetProducts() =>
            await _dynamoDBContext.ScanAsync<Product>(default).GetRemainingAsync();

        public async Task<Product> GetProduct(string id)
        {
            return await _dynamoDBContext.LoadAsync<Product>(id);
        }

        public async void CreateOrUpdateProduct(Product product)
        {
            await _dynamoDBContext.SaveAsync(product);
        }


        public async void RemoveProduct(Product productIn) =>
            await _dynamoDBContext.DeleteAsync<Product>(productIn.Id);

        public async void RemoveProduct(string id) =>
            await _dynamoDBContext.DeleteAsync<Product>(id);


        public async Task<List<Bid>> GetBids(string productId)
        {
            var scanCondition = new List<ScanCondition>() { new ScanCondition("ProductId", ScanOperator.Equal, productId)
                                                            };
           
            return await _dynamoDBContext.ScanAsync<Bid>(scanCondition).GetRemainingAsync();
      
        }

        public async Task<Bid> GetBid(string id) =>
             await _dynamoDBContext.LoadAsync<Bid>(id);

        public async void CreateOrUpdateBid(Bid bid)
        {
            await _dynamoDBContext.SaveAsync(bid);
        }

        public async void RemoveBid(Bid bidIn) =>
             await _dynamoDBContext.DeleteAsync<Bid>(bidIn);

        public async void RemoveBid(string id) =>
             await _dynamoDBContext.DeleteAsync<Bid>(id);
    }
}
