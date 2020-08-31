using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class PreferredSwapTimeController : BaseController<Model.PreferredSwapTime, object>
    {
        public PreferredSwapTimeController(IService<Model.PreferredSwapTime, object> service): base(service)
        {

        }
    }
}
