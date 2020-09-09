using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;

namespace ZamjenaDomova.WebAPI.Services
{
    public class RoleService : BaseService<Model.Role, RoleSearchRequest, Database.Role>
    {
        public RoleService(ZamjenaDomovaContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IList<Model.Role> Get(RoleSearchRequest search)
        {

            if (search?.UserId.HasValue == true)
            {
                var query = _context.Set<UserRole>().Where(x => x.UserId == search.UserId)
                                                         .Include(x => x.Role)
                                                         .Select(x => new { x.RoleId, x.Role.Name })
                                                         .OrderBy(x => x.Name)
                                                         .ToList();

                var list = new List<Model.Role>();

                foreach (var item in query)
                {
                    list.Add(new Model.Role
                    {
                        Name = item.Name,
                        RoleId = item.RoleId
                    });
                }

                return list;
            }

            return _mapper.Map<List<Model.Role>>(_context.Set<Role>().OrderBy(x => x.Name).ToList());
        }
    }
}
