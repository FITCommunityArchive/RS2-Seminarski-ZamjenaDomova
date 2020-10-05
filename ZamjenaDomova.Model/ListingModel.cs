using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class ListingModel
    {
        public int ListingId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Persons { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public byte[] Image { get; set; }
    }
}
