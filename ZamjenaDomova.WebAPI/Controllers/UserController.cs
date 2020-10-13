using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<List<Model.User>> Get([FromQuery] UserSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize]
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
        [Authorize(Roles = "Administrator, User, Editor")]
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            _service.ChangePassword(userEmail, model);
            return Ok("Password uspješno promijenjen!");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserUpsertRequest request)
        {
            request.Roles = new List<int>();
            request.Roles.Add(3);
            _service.Insert(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            return _service.Delete(id);
        }
        [HttpPost("ChangeProfilePicture")]
        public IActionResult ChangeProfilePicture([FromBody] byte[] imageArray)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            var response = _service.ChangeProfilePicture(userEmail, imageArray);
            if (response == null) return BadRequest("Greška pri uploadu slike!");
            return Ok("Profilna slika uspješno promijenjena!");
        }
    }
}
