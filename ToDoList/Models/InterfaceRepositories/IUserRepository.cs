namespace Models.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

public interface IUserRepository
{
    Task<ApiResponse<List<User>>> GetAllUsers();
    Task<ApiResponse<User>> GetUserById(Guid id);
    Task<ApiResponse<User>> CreateUser(User user);
    Task<ApiResponse<User>> UpdateUser(Guid id, User user);
    Task<ApiResponse<User>> DeleteUser(Guid id);
}
