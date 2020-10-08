using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
