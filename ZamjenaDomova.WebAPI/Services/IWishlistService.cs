using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IWishlistService
    {
        Model.WishlistListing Save(Model.Requests.WishlistListingInsertRequest request);
        bool Remove(int wishlistId, int listingId);
        List<ListingModel> GetWishlistItems(int wishlistId);
        bool IsOnWishlist(int wishlistId, int listingId);
    }
}
