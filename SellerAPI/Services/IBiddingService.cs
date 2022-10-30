using SellerAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SellerAPI.Services
{
    public interface IBiddingService
    {
        void CreateOrUpdateBid(Bid bid);
        void CreateOrUpdateProduct(Product product);
        Task<Bid> GetBid(string id);
        Task<List<Bid>> GetBids(string productId);
        Task<Product> GetProduct(string id);
        Task<List<Product>> GetProducts();
        void RemoveBid(Bid bidIn);
        void RemoveBid(string id);
        void RemoveProduct(Product productIn);
        void RemoveProduct(string id);
    }
}