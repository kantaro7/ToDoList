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

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly TDContext _context;
    public UserRepository(IMapper autoMapper, IConfiguration configuration)
    {
        _mapper = autoMapper;
        _context = new TDContext(configuration);
    }

    public async Task<ApiResponse<List<User>>> GetAllUsers()
    {
        try
        {
            List<UserEntity> userEntities = await _context.Users.Where(x => x.Status).ToListAsync();
            return new ApiResponse<List<User>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<User>>(userEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<User>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<User>> GetUserById(Guid id)
    {
        try
        {
            UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            return userEntity is null
                ? new ApiResponse<User>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null)
                : new ApiResponse<User>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<User>(userEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<User>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<User>> CreateUser(User task)
    {
        try
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(task);
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<User>(Enums.ResponsesID.Successful, "Tarea creada exitosamente", _mapper.Map<User>(userEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<User>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<User>> UpdateUser(Guid id, User task)
    {
        try
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(task);
            UserEntity exist = await _context.Users.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            if (exist is null) 
                return new ApiResponse<User>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
                
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<User>(Enums.ResponsesID.Successful, "Tarea actualizada exitosamente", _mapper.Map<User>(userEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<User>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<User>> DeleteUser(Guid id)
    {
        try 
        {
            UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            if (userEntity is null)
                return new ApiResponse<User>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            userEntity.Status = false;
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<User>(Enums.ResponsesID.Successful, "Tarea eliminada exitosamente", _mapper.Map<User>(userEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<User>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }
}
