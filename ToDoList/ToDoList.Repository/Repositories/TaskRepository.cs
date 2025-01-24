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

public class TaskRepository : ITaskRepository
{
    private readonly IMapper _mapper;
    private readonly TDContext _context;
    public TaskRepository(IMapper autoMapper, IConfiguration configuration)
    {
        _mapper = autoMapper;
        _context = new TDContext(configuration);
    }

    //crea los metodos para el CRUD de Task con entity framework tomando en cuenta los metodos de la interfaz ITaskService
    public async Task<ApiResponse<List<Models.Task>>> GetAllTasks()
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<List<Models.Task>>> GetTasksByUser(Guid userId)
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status && x.UserId == userId).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<List<Models.Task>>> GetPendingTasksByUser(Guid userId)
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status && x.UserId == userId && x.IsComplete == false).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<List<Models.Task>>> GetCompletedTasksByUser(Guid userId)
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status && x.UserId == userId && x.IsComplete).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<List<Models.Task>>> GetPendingTasks()
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status && x.IsComplete == false).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<List<Models.Task>>> GetCompletedTasks()
    {
        try
        {
            List<TaskEntity> taskEntities = await _context.Tasks.Where(x => x.Status && x.IsComplete).ToListAsync();
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<List<Models.Task>>(taskEntities));
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Models.Task>>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> GetTaskById(Guid id)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            return taskEntity is null
                ? new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null)
                : new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Consulta Exitosa", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> CreateTask(Models.Task task)
    {
        try
        {
            TaskEntity taskEntity = _mapper.Map<TaskEntity>(task);
            await _context.Tasks.AddAsync(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea creada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task)
    {
        try
        {
            TaskEntity taskEntity = _mapper.Map<TaskEntity>(task);
            TaskEntity exist = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            if (exist is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);

            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea actualizada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> DeleteTask(Guid id)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.Status);
            if (taskEntity is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            taskEntity.Status = false;
            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea eliminada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> CompleteTaskByUser(Guid taskId, Guid userId)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.Status && !t.IsComplete && t.UserId == userId);
            if (taskEntity is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            taskEntity.IsComplete = true;
            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea completada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> CompleteTask(Guid taskId)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.Status && !t.IsComplete);
            if (taskEntity is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            taskEntity.IsComplete = true;
            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea completada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> UpdateTaskByUser(Guid userId, string name, Guid taskId)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.Status && t.UserId == userId);
            if (taskEntity is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            taskEntity.Name = name;
            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea actualizada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }

    public async Task<ApiResponse<Models.Task>> DeleteTaskByUser(Guid taskId, Guid userId)
    {
        try
        {
            TaskEntity taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.Status && t.UserId == userId);
            if (taskEntity is null)
                return new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Tarea no encontrada", null);
            taskEntity.Status = false;
            _context.Tasks.Update(taskEntity);
            await _context.SaveChangesAsync();
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Successful, "Tarea eliminada exitosamente", _mapper.Map<Models.Task>(taskEntity));
        }
        catch (Exception ex)
        {
            return new ApiResponse<Models.Task>(Enums.ResponsesID.Error, ex.Message, null);
        }
    }
}
