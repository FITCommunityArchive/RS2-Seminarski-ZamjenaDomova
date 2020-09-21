using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingAmenityController
    {
        private readonly IListingService _service;
        public ListingAmenityController(IListingService service)
        {
            _service = service;
        }
        [HttpGet]
        public IList<Model.AmenityModel> GetByListing([FromQuery] ListingAmenitySearchRequest request)
        {
            return _service.GetAmenities(request.ListingId);
        }
        
    }
}
