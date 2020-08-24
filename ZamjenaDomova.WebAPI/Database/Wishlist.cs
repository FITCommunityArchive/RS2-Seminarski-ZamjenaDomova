using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class Wishlist
    {
        public int WishlistId { get; set; }       
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
