namespace Models.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

public interface IAuthenticationRepository
{
    Task<ApiResponse<User>> Login(Login data);
}
