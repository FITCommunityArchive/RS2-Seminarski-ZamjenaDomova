using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class AmenityController : BaseCRUDController<Model.Amenity, Model.Requests.AmenitySearchRequest, Model.Requests.AmenityUpsertRequest, Model.Requests.AmenityUpsertRequest>
    {
        public AmenityController(ICRUDService<Model.Amenity,Model.Requests.AmenitySearchRequest, Model.Requests.AmenityUpsertRequest, Model.Requests.AmenityUpsertRequest> service):base(service)
        {

        }
    }
}
