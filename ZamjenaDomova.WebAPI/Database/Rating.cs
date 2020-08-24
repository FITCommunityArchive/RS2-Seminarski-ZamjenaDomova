using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RatingValue { get; set; }
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
