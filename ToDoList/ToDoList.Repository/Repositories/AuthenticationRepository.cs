namespace ToDoList.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoList.Repository.Context;
using SQLEntities;
using Models.InterfaceRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Common;
using Models;
using Microsoft.Extensions.Configuration;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly IMapper _mapper;
    private readonly TDContext _context;
    public AuthenticationRepository(IMapper autoMapper, IConfiguration configuration)
    {
        _mapper = autoMapper;
        _context = new TDContext(configuration);
    }

    public async Task<ApiResponse<User>> Login(Login data)
    {
        try
        {
            UserEntity userEntities = await _context.Users.FirstOrDefaultAsync(x => x.Status && x.Email.ToLower().Equals(data.Email.ToLower()) && x.Password.Equals(data.Password));
            if (userEntities == null)
            {
                return new ApiResponse<User>(Enums.ResponsesID.Error, "Email o contraseña incorrectos", null);
            }
            else
            {
                return new ApiResponse<User>(Enums.ResponsesID.Successful, "Exitoso", _mapper.Map<User>(userEntities));
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<User>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }
}
