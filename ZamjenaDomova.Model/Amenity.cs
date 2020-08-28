using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; }
        public int AmenitiesCategoryId { get; set; }
    }
}
