using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class AmenitySearchRequest
    {
        public string Name { get; set; }
        public int? AmenitiesCategoryId { get; set; }
    }
}
