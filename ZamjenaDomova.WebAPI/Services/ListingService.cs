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
            try
            {
                var entity = new Database.Listing
                {
                    Address = listing.Address,
                    AreaDescription = listing.AreaDescription,
                    Bathrooms = listing.Bathrooms,
                    Beds = listing.Beds,
                    City = listing.City,
                    ListingDescription = listing.ListingDescription,
                    Active = true,
                    Approved = false,
                    DateCreated = DateTime.Now,
                    DateApproved = new DateTime(),
                    Name = listing.Name,
                    Persons = listing.Persons,
                    TerritoryId = listing.TerritoryId,
                    UserId = listing.UserId
                };
                _context.Listing.Add(entity);
                _context.SaveChanges();

                foreach(var item in listing.Amenities)
                {
                    var ListingAmenity = new ListingAmenity();
                    ListingAmenity.ListingId = entity.ListingId;
                    ListingAmenity.AmenityId = item;
                    _context.ListingAmenity.Add(ListingAmenity);
                    _context.SaveChanges();
                }

                return new ListingResponse
                {
                    ListingId = entity.ListingId,
                    Message = "Uspješno dodan oglas",
                    Status = true
                };
            }
            catch(Exception ex)
            {
                return new ListingResponse
                {
                    Message = ex.Message,
                    Status = false
                };
            }
        }
    }
}
