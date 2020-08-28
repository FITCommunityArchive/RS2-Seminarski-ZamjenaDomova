using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class AmenityController : BaseCRUDController<Model.Amenity, Model.Requests.AmenitySearchRequest, object, object>
    {
        public AmenityController(AmenityService service):base(service)
        {

        }
    }
}
