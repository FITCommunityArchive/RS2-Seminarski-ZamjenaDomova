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
    }
}
