using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{wishlistId}")]
        public ActionResult<List<Model.ListingModel>> Get(int wishlistId)
        {
            return _service.GetWishlistItems(wishlistId);
        }
    }
}
