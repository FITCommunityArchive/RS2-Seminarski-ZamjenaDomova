using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class ListingImage
    {
        public int ListingImageId { get; set; }
        public byte[] Image { get; set; }
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
    }
}

