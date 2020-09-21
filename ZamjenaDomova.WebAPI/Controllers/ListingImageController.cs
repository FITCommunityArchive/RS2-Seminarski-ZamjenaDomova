using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZamjenaDomova.Model;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI.Controllers
{
    public class ListingImageController : BaseCRUDController<ListingImageModel, object, ListingImageModel, ListingImageModel>
    {
        
        public ListingImageController(ICRUDService<Model.ListingImageModel, object, Model.ListingImageModel, Model.ListingImageModel> service) : base(service)
        {
            
        }
    }
}
