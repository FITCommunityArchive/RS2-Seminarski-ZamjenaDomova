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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Administrator,Editor")]
        [HttpGet]
        public ActionResult<List<Model.User>> Get([FromQuery] UserSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]

        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Model.User Insert(UserUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.User Update(int id, UserUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _service.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email ili lozinka nisu ispravni!" });

            return Ok(user);
        }
    }
}
