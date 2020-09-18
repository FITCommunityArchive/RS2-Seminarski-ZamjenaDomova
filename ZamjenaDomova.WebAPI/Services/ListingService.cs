using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;

namespace ZamjenaDomova.WebAPI.Services
{
    public class ListingService : IListingService
    {
        private readonly ZamjenaDomovaContext _context;
        private readonly IMapper _mapper;
        public ListingService(ZamjenaDomovaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.ListingResponse Insert(ListingInsertRequest listing)
        {
            var entity = new Database.Listing
            {
                Address = listing.Address,
                AreaDescription = listing.AreaDescription,
                Bathrooms = listing.Bathrooms,
                Beds = listing.Beds,
                City = listing.City,
                ListingDescription=listing.ListingDescription
            };

            return new ListingResponse { ListingId = entity.ListingId };
        }
    }
}
