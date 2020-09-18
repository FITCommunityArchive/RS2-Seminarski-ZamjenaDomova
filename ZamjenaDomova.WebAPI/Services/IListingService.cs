using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IListingService
    {
        //List<Model.Listing> Get(UserSearchRequest request);
        //Model.User GetById(int id);
        Model.ListingResponse Insert(ListingInsertRequest listing);
        //Model.User Update(int id, UserUpsertRequest request);
    }
}
