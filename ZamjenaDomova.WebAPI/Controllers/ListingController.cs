using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _service;

        public ListingController(IListingService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Model.Requests.ListingInsertRequest request)
        {
            var response = _service.Insert(request);
            if (!response.Status)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpGet]
        public ActionResult<List<Model.Listing>> Get([FromQuery] ListingSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("Count")]
        public ActionResult<List<Model.ListingCountModel>>GetCount([FromQuery] ListingsCountSearchRequest request)
        {
            return _service.GetCount(request);
        }
        [HttpPost("GetListingsModels")]
        public ActionResult<List<Model.ListingModel>> GetListingsModels(ListingsModelsSearchRequest request)
        {
            return _service.GetListingsModels(request);
        }
        [HttpGet("GetListingDetails/{listingId}")]
        public ActionResult<ListingDetailsModel> GetListingDetails(int listingId)
        {
            return _service.GetListingDetails(listingId);
        }
        [HttpGet("MyListings/{userId}/{approved}")]
        public ActionResult<List<Model.ListingModel>> MyListings(int userId, bool approved)
        {
            return _service.MyListings(userId,approved);
        }
        [HttpGet("{id}")]

        public Model.Listing GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPut("{id}")]
        public Model.Listing Update(int id, ListingUpdateRequest request)
        {
            return _service.Update(id, request);
        }

    }
}
