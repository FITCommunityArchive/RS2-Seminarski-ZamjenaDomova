﻿using ZamjenaDomova.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Services
{
    public interface IUserService
    {
        List<Model.User> Get(UserSearchRequest request);

        Model.User Insert(UserInsertRequest request);
        Model.User Update(int id, UserUpdateRequest request);
    }
}
