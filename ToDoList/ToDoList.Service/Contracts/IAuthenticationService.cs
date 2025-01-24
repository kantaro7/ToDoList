namespace ToDoList.Service.Contracts;
using Common;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAuthenticationService
{
    Task<ApiResponse<Models.User>> Login(Models.Login data);
}

