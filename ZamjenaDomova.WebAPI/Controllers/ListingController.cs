using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
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
        [Authorize(Roles = "Administrator, Editor")]
        [HttpGet]
        public ActionResult<List<Model.Listing>> Get([FromQuery] ListingSearchRequest request)
        {
            return _service.Get(request);
        }
    }
}
