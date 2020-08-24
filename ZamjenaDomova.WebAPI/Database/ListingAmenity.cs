using ZamjenaDomova.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class ListingAmenity
    {
        public int ListingAmenityId { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
