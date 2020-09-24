﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
                if (!string.IsNullOrWhiteSpace(request.City))
                    query = query.Where(x => x.City.StartsWith(request.City));
                if (request.StartDate != null)
                    query = query.Where(x => x.DateApproved > request.StartDate);
                if (request.EndDate != null)
                    query = query.Where(x => x.DateApproved < request.EndDate);
            }
            var list = query.Select(x => new Model.Listing
            {
                Address = x.Address,
                AreaDescription = x.AreaDescription,
                Bathrooms = x.Bathrooms,
                Beds = x.Beds,
                City = x.City,
                DateCreated = x.DateCreated,
                DateApproved=x.DateApproved,
                ListingDescription = x.ListingDescription,
                Name = x.Name,
                Persons = x.Persons,
                TerritoryName = x.Territory.Name,
                UserName = x.User.FirstName + " " + x.User.LastName,
                ListingId = x.ListingId
            }).ToList();

            return list;
        }

        public Model.Listing GetById(int id)
        {
            var listing = _context.Listing.Include(x => x.Territory).FirstOrDefault(x => x.ListingId == id);

            if (listing == null)
                return new Model.Listing();

            //mapping properties
            var result = new Model.Listing
            {
                ListingId = listing.ListingId,
                Address = listing.Address,
                Approved = listing.Approved,
                AreaDescription = listing.AreaDescription,
                Bathrooms = listing.Bathrooms,
                Beds = listing.Beds,
                City = listing.City,
                DateCreated = listing.DateCreated,
                ListingDescription = listing.ListingDescription,
                Name = listing.Name,
                Persons = listing.Persons,
                TerritoryName = listing.Territory.Name,
                UserName = listing.User.FirstName + " " + listing.User.LastName
            };
            //mapping amenities
            var listingAmenities = _context.ListingAmenity.Where(x => x.ListingId == id);
            if (listingAmenities.Count() > 0)
            {
                result.Amenities = new List<Model.Amenity>();
                foreach (var item in listingAmenities.Include(x => x.Amenity))
                    result.Amenities.Add(new Model.Amenity
                    {
                        AmenityId = item.AmenityId,
                        Name = item.Amenity.Name
                    });
            }
            //mapping images
            if (_context.ListingImage.Any(x => x.ListingId == listing.ListingId))
            {
                result.Image = _context.ListingImage.FirstOrDefault(x => x.ListingId == listing.ListingId).Image;
                foreach (var image in _context.ListingImage.Where(x => x.ListingId == listing.ListingId)
                                                          .ToList())
                {
                    result.Images.Add(new ListingImageModel
                    {
                        ListingId = image.ListingId,
                        Image = image.Image
                    });
                }
            }

            return result;
        }
        public IList<Model.AmenityModel> GetAmenities(int listingId)
        {
            var amenities = _context
                .Set<Database.ListingAmenity>()
                .Include(x => x.Amenity)
                .Where(x => x.ListingId == listingId)
                .ToList();

            return _mapper.Map<List<Model.AmenityModel>>(amenities);
        }

        public Model.Listing Update(int id, [FromBody] ListingUpdateRequest request)
        {
            var entity = _context.Listing.FirstOrDefault(x => x.ListingId == id);
            _context.Listing.Attach(entity);
            _context.Listing.Update(entity);
            if (request.Approved)
            {
                entity.Approved = request.Approved;
                entity.DateApproved = request.ApprovalTime;
                _context.SaveChanges();

                return _mapper.Map<Model.Listing>(entity);
            }

            else
            {
                _context.Listing.Remove(entity);
                _context.SaveChanges();
                return new Model.Listing();
            }
        }
    }
}