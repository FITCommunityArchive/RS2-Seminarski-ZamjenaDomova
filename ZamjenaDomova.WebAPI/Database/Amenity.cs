using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; }
        public int AmenitiesCategoryId { get; set; }
        public virtual AmenitiesCategory AmenitiesCategory { get; set; }
    }
}
