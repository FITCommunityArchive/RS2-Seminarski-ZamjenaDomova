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
        [HttpGet("{id}")]

        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.User Insert(UserUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("id")]
        public Model.User Update(int id, UserUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
