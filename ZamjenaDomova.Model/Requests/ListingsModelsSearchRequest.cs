using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class ListingsModelsSearchRequest
    {
        public string City { get; set; }
        public string Name { get; set; }
        public int? TerritoryId { get; set; }
        public int? Persons { get; set; }
        public int? Beds { get; set; }
        public int? Bathrooms { get; set; }
        public int? UserId { get; set; }
    }
}
