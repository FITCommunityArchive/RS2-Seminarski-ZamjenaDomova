using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class ZamjenaDomovaContext : DbContext
    {
        public ZamjenaDomovaContext()
        {
        }

        public ZamjenaDomovaContext(DbContextOptions<ZamjenaDomovaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmenitiesCategory> AmenitiesCategory { get; set; }
        public virtual DbSet<Amenity> Amenity { get; set; }
        public virtual DbSet<Listing> Listing { get; set; }
        public virtual DbSet<ListingAmenity> ListingAmenity { get; set; }
        public virtual DbSet<ListingImage> ListingImage { get; set; }
        public virtual DbSet<PreferredSwapTime> PreferredSwapTime { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<WishlistListing> WishlistListing { get; set; }
        
    }
}