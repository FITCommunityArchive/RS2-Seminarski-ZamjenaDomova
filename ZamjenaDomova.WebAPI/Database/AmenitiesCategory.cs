using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class AmenitiesCategory
    {
        public int AmenitiesCategoryId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
