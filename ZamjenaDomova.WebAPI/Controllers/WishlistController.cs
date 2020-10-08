using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _service;
        public WishlistController(IWishlistService service)
        {
            _service = service;
        }
        [HttpPost]
        public Model.WishlistListing Save(WishlistListingInsertRequest request)
        {
            return _service.Save(request);
        }
        [HttpDelete("{wishlistId}/{listingId}")]
        public bool Remove(int wishlistId, int listingId)
        {
            return _service.Remove(wishlistId, listingId);
        }
        [HttpGet("{wishlistId}")]
        public ActionResult<List<Model.ListingModel>> Get(int wishlistId)
        {
            return _service.GetWishlistItems(wishlistId);
        }
        [HttpGet("IsOnWishlist/{wishlistId}/{listingId}")]
        public ActionResult<bool> IsOnWishlist(int wishlistId, int listingId)
        {
            return _service.IsOnWishlist(wishlistId, listingId);
        }
    }
}
