﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class ListingInsertRequest
    {
        public string Name { get; set; }
        //General info and location
        public string ListingDescription { get; set; }
        public string AreaDescription { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int TerritoryId { get; set; }
        //Capacity
        public int Persons { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        //Owner
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<int> Amenities { get; set; }
    }
}
