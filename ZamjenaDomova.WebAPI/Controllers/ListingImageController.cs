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
        private readonly ListingImageService _service;
        public ListingImageController(ListingImageService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("GetByListing/{listingId}")]
        public IList<Model.ListingImageModel> GetByListing(int listingId)
        {
            return _service.GetByListing(listingId);
        }
        
    }
}
