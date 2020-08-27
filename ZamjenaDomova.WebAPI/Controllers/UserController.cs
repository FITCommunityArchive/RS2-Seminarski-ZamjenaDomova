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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.User>> Get([FromQuery]UserSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.User Insert(UserInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("id")]
        public Model.User Update(int id, UserUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
