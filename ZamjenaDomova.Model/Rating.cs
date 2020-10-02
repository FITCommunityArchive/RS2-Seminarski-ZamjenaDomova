using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class Rating
    {
        public int RatingValue { get; set; }
        public int ListingId { get; set; }
        public int UserId { get; set; }
        public double AverageRating { get; set; }
    }
}
