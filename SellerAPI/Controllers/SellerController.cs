using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellerAPI.Model;
using SellerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IBiddingService _biddingService;

        public SellerController(IBiddingService biddingService)
        {
            _biddingService = biddingService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _biddingService.GetProducts();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _biddingService.GetProduct(id);

            if (product == null )
            {
                return NotFound();
            }

            return product;
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<ActionResult<Product>> AddProduct(Product model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                //Additional validation
                string ValidCategoris = "Painting,Sculptor,Ornament";
                if (!string.IsNullOrWhiteSpace(model.Category) && !ValidCategoris.Split(",").Contains(model.Category))
                {
                    return BadRequest("Please provide a valid category");
                }
                else if (model.EndDate<= System.DateTime.Now)
                {
                    return BadRequest("Bid end date should be future date");
                }
                model.Id = Guid.NewGuid().ToString();
                _biddingService.CreateOrUpdateProduct(model);
                return CreatedAtRoute("GetProduct", new { id = model.Id.ToString() }, model);

            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _biddingService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else if (product.EndDate < System.DateTime.Now)
            {
                return BadRequest("Bid end date is already expired");
            }
            var bids = await _biddingService.GetBids(id);

            if(bids != null && bids.Count() >0)
            {
                return BadRequest("There is already bid exists for the product");
            }

            _biddingService.RemoveProduct(id);

            return NoContent();
        }
        [HttpGet("show-bids/{productId}")]
        public async Task<ActionResult<ProductBidDetails>> ShowBids(string productId)
        {
            var product = await _biddingService.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }
            
            ProductBidDetails productBidDetails = new ProductBidDetails()
            {
                ProductName = product.ProductName,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Category = product.Category,
                StartingPrice = product.StartingPrice,
                EndDate = product.EndDate
            };

            var bids = await _biddingService.GetBids(productId);
            
            if(bids!= null)
            {
                productBidDetails.Bids = bids.OrderByDescending(bid => bid.BidAmount).ToList();
            }
            return productBidDetails;
        }
    }
}
