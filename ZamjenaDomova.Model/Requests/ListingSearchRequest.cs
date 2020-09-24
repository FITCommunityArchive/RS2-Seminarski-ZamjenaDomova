using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class ListingSearchRequest
    {
        public bool Approved { get; set; }
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
