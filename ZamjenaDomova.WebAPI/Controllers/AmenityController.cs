using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class AmenityController : BaseController<Model.Amenity, object>
    {
        public AmenityController(IService<Model.Amenity, object> service) :base(service)
        {

        }
    }
}
