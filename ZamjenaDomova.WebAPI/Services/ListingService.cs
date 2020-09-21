using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

                foreach (var item in listing.Amenities)
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
            catch (Exception ex)
            {
                return new ListingResponse
                {
                    Message = ex.Message,
                    Status = false
                };
            }
        }

        public List<Model.Listing> Get(ListingSearchRequest request)
        {
            var query = _context.Listing.Include(x => x.Territory).Include(x => x.User).AsQueryable();
            if (request != null)
            {
                query = query.Where(x => x.Approved == request.Approved);
            //if (!string.IsNullOrWhiteSpace(request?.Name))
            //    query = query.Where(x => x.FirstName.StartsWith(request.Name) || x.LastName.StartsWith(request.Name));

                //var list = query.ToList();
            }
            var list = query.Select(x => new Model.Listing
            {
                Active = x.Active,
                Address = x.Address,
                AreaDescription = x.AreaDescription,
                Bathrooms = x.Bathrooms,
                Beds = x.Beds,
                City = x.City,
                DateCreated = x.DateCreated,
                ListingDescription = x.ListingDescription,
                Name = x.Name,
                Persons = x.Persons,
                TerritoryName = x.Territory.Name,
                UserName = x.User.FirstName + " " + x.User.LastName,
                ListingId=x.ListingId
            }).ToList();

            return list;
        }
    }
}
