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
    public class ListingAmenityController:ControllerBase
    {
        private readonly IListingService _service;
        public ListingAmenityController(IListingService service)
        {
            _service = service;
        }
        [HttpGet]
        public IList<Model.AmenityModel> Get(int ListingId)
        {
            return _service.GetAmenities(ListingId);
        }
        
    }
}
