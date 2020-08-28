using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;


namespace ZamjenaDomova.WebAPI.Services
{
    public class AmenityService : BaseCRUDService<Model.Amenity, AmenitySearchRequest, Database.Amenity, object, object>
    {
        public AmenityService(ZamjenaDomovaContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IList<Model.Amenity> Get(AmenitySearchRequest search)
        {
            var query = _context.Set<Database.Amenity>().AsQueryable();

            if (search.AmenitiesCategoryId.HasValue == true)
                query = query.Where(x => x.AmenitiesCategoryId == search.AmenitiesCategoryId);
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.StartsWith(search.Name));

            return _mapper.Map<List<Model.Amenity>>(query.ToList());
        }

    }
}
