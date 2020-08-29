using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class AmenityUpsertRequest
    {
        public string Name { get; set; }
        public int? AmenitiesCategoryId { get; set; }
    }
}
