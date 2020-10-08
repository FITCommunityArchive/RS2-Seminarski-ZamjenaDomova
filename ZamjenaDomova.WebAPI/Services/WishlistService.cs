using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;

namespace ZamjenaDomova.WebAPI.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly ZamjenaDomovaContext _context;
        private readonly IMapper _mapper;
        public WishlistService(ZamjenaDomovaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.WishlistListing Save(WishlistListingInsertRequest request)
        {
            var entity = _mapper.Map<Database.WishlistListing>(request);
            _context.WishlistListing.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.WishlistListing>(entity);
        }

        public bool Remove(int wishlistId, int listingId)
        {
            var entity = _context.WishlistListing
                .First(x => x.WishlistId == wishlistId && x.ListingId == listingId);

            _context.WishlistListing.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<ListingModel> GetWishlistItems(int wishlistId)
        {
            var wishlistItems = _context.WishlistListing.Where(x => x.WishlistId == wishlistId).ToList();
            var result = new List<ListingModel>();
            foreach (var item in wishlistItems)
            {
                var listing = _context.Listing.First(x => x.ListingId == item.ListingId);
                var newListingModel = new ListingModel
                {
                    ListingId = listing.ListingId,
                    Bathrooms = listing.Bathrooms,
                    Beds = listing.Beds,
                    City = listing.City,
                    Name = listing.Name,
                    Persons = listing.Persons
                };
                if (_context.ListingImage.Any(x => x.ListingId == item.ListingId))
                    newListingModel.Image = _context.ListingImage.FirstOrDefault(x => x.ListingId == item.ListingId).Image;
                result.Add(newListingModel);
            }
            return result;
        }

        public bool IsOnWishlist(int wishlistId, int listingId)
        {
            return _context.WishlistListing
                .Where(x => x.WishlistId == wishlistId)
                .Where(x => x.ListingId == listingId).Any();
        }
    }
}
