using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class RoleController : BaseController<Model.Role, object>
    {
        public RoleController(IService<Model.Role, object> service) : base(service)
        {

        }
    }
}
