using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; } 
        public virtual Role Role { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
       
    }
}
