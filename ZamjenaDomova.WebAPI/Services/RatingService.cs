using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.WebAPI.Database;

namespace ZamjenaDomova.WebAPI.Services
{
    public class RatingService:BaseCRUDService<Model.Rating, object, Database.Rating, Model.Rating, Model.Rating>
    {
        public RatingService(ZamjenaDomovaContext context, IMapper mapper):base(context, mapper)
        {

        }
        public override Model.Rating Insert(Model.Rating request)
        {
            var existingRating = _context.Rating.FirstOrDefault(x => x.ListingId == request.ListingId && x.UserId == request.UserId);

            if (existingRating == null)
            {
                _context.Rating.Add(new Rating
                {
                    UserId = request.UserId,
                    ListingId = request.ListingId,
                    RatingValue = request.RatingValue
                });
            }
            else
            {
                existingRating.RatingValue = request.RatingValue;
            }
            _context.SaveChanges();
            return new Model.Rating
            {
                AverageRating = _context.Rating.Where(x => x.ListingId == request.ListingId).Average(x => x.RatingValue)
            };
        }

        public int GetRatingByListingAndUser(int listingId, int userId)
        {
            var result = _context.Rating.FirstOrDefault(x => x.ListingId == listingId && x.UserId == userId);
            if (result != null)
            {
                return result.RatingValue;
            }
            else
            {
                return -1;
            }
        }

        public List<Model.Rating> GetByListing(int listingId)
        {
            var existingRating = _context.Rating.FirstOrDefault(x => x.ListingId == listingId);
            if (existingRating == null)
            {
                return null;
            }

            return _mapper.Map<List<Model.Rating>>(_context.Rating.Where(x => x.ListingId == listingId).ToList());
        }
    }
}
