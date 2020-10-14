using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class ListingDetailsModel
    {
        public int ListingId { get; set; }
        public string Name { get; set; }
        //General info and location
        public string ListingDescription { get; set; }
        public string AreaDescription { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string TerritoryName { get; set; }
        //Capacity
        public int Persons { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        //Owner
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public DateTime DateApproved { get; set; }

        public List<Amenity> Amenities { get; set; }
        public byte[] UserImage { get; set; }
    }
}
