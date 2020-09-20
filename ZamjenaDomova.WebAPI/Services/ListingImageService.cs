using AutoMapper;
using ZamjenaDomova.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Services
{
    public class ListingImageService : BaseCRUDService<Model.ListingImageModel, object, ListingImage, Model.ListingImageModel, Model.ListingImageModel>
    {
        public ListingImageService(ZamjenaDomovaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IList<Model.ListingImageModel> GetByListing(int listingId)
        {
            var result = _context.ListingImage.Where(x => x.ListingId == listingId);
            return _mapper.Map<List<Model.ListingImageModel>>(result);
        }
    }
}
