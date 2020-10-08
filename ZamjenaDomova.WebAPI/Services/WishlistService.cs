using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;

namespace ZamjenaDomova.WebAPI.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly ZamjenaDomovaContext _context;
        private readonly IMapper _mapper;
        public WishlistService(ZamjenaDomovaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.WishlistListing Insert(WishlistListingInsertRequest request)
        {
            var entity = _mapper.Map<Database.WishlistListing>(request);
            _context.WishlistListing.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.WishlistListing>(entity);
        }
    }
}
