namespace ToDoList.Service.Contracts;
using Common;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<ApiResponse<List<Models.User>>> GetAllUsers();
    Task<ApiResponse<Models.User>> GetUserById(Guid id);
    Task<ApiResponse<Models.User>> CreateUser(Models.User task);
    Task<ApiResponse<Models.User>> UpdateUser(Guid id, Models.User task);
    Task<ApiResponse<Models.User>> DeleteUser(Guid id);
}

