using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class TerritoryController : BaseController<Model.Territory, object>
    {
        public TerritoryController(IService<Model.Territory, object> service):base(service)
        {

        }
    }
}
