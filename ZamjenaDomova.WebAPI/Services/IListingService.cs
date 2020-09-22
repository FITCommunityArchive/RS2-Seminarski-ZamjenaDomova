using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IListingService
    {
        List<Model.Listing> Get(ListingSearchRequest request);
        Model.Listing GetById(int id);
        Model.ListingResponse Insert(ListingInsertRequest listing);
        Model.Listing Update(int id, bool approval);
        public IList<Model.AmenityModel> GetAmenities(int listingId);
    }
}
