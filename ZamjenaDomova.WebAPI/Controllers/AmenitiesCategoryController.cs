using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class AmenitiesCategoryController : BaseController<Model.AmenitiesCategory, object>
    {
        public AmenitiesCategoryController(IService<Model.AmenitiesCategory, object> service):base(service)
        {

        }
    }
}
