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
    public class RoleController : BaseController<Model.Role, RoleSearchRequest>
    {
        public RoleController(IService<Model.Role, RoleSearchRequest> service) : base(service)
        {

        }
    }
}
