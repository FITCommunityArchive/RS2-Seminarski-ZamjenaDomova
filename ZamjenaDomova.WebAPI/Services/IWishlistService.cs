using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IWishlistService
    {
        Model.WishlistListing Insert(Model.Requests.WishlistListingInsertRequest request);
        List<ListingModel> GetWishlistItems(int wishlistId);
    }
}
