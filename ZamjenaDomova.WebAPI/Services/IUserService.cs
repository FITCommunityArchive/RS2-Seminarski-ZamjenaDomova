using ZamjenaDomova.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IUserService
    {
        List<Model.User> Get(UserSearchRequest request);
        Model.User GetById(int id);
        Model.User Insert(UserUpsertRequest request);
        Model.User Update(int id, UserUpsertRequest request);
        Model.User Delete(int id);

        Model.UserResponse Authenticate(string email, string password);
        Model.User ChangePassword(string userEmail, ChangePasswordModel model);
    }
}
