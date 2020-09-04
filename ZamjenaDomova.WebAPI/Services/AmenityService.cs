using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;


namespace ZamjenaDomova.WebAPI.Services
{
    public class AmenityService : BaseCRUDService<Model.Amenity, AmenitySearchRequest, Database.Amenity, Model.Requests.AmenityUpsertRequest, Model.Requests.AmenityUpsertRequest>
    {
        public AmenityService(ZamjenaDomovaContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IList<Model.Amenity> Get(AmenitySearchRequest search)
        {
            var query = _context.Set<Database.Amenity>().Include(x=> x.AmenitiesCategory).
                AsQueryable();

            if (search.AmenitiesCategoryId.HasValue == true)
                query = query.Where(x => x.AmenitiesCategoryId == search.AmenitiesCategoryId);
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.StartsWith(search.Name));

            query = query.OrderBy(x => x.AmenitiesCategory.Name).ThenBy(x=> x.Name);
            return _mapper.Map<List<Model.Amenity>>(query.ToList());
        }

    }
}
