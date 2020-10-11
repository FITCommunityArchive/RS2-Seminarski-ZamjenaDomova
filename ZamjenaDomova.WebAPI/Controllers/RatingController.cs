using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZamjenaDomova.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : BaseCRUDController<Model.Rating, object, Model.Rating, Model.Rating>
    {
        private readonly RatingService service;

        public RatingController(RatingService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetRatingsByListing/{listingId}")]
        public List<Model.Rating> GetRatingsByListing(int listingId)
        {
            return service.GetRatingsByListing(listingId);
        }

        [HttpGet("GetRatingByListingAndUser/{listingId}/{userId}")]
        public int GetRatingByListingAndUser(int listingId, int userId)
        {
            return service.GetRatingByListingAndUser(listingId, userId);
        }
    }
}