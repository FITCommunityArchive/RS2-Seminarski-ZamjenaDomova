using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.User, Model.User>();
            CreateMap<Model.Requests.UserUpsertRequest, Database.User>();
            CreateMap<Database.AmenitiesCategory, Model.AmenitiesCategory>();
            CreateMap<Database.Amenity, Model.Amenity>().ForMember(dest=> dest.AmenitiesCategoryName, opt => opt.MapFrom(src=> src.AmenitiesCategory.Name));
            CreateMap<Model.Requests.AmenityUpsertRequest, Database.Amenity>();
            CreateMap<Database.Role, Model.Role>();
            //CreateMap<Model.Listing, Database.Listing>();
        }
    }
}
