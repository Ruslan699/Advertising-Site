﻿using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Repositories
{
    public interface IUserRepository:IBaseIdentityRepository<UserDto>
    {
        Task<ActionResponse> SignIn(string email, string password, bool rememberMe=false);
    }
}
