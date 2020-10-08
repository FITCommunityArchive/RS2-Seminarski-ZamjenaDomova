using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class WishlistListingInsertRequest
    {
        public int WishlistId { get; set; }
        public int ListingId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
