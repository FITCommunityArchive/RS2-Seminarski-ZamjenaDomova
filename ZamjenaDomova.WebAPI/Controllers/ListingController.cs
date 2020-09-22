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
        [HttpGet("{id}")]

        public Model.Listing GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPut("{id}")]
        public Model.Listing Update(int id, bool approval)
        {
            return _service.Update(id, approval);
        }

    }
}
