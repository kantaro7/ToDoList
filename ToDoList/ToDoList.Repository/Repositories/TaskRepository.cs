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

public class TaskRepository : ITaskRepository
{
    private readonly IMapper _mapper;
    private readonly TDContext _context;
    public TaskRepository(IMapper autoMapper, TDContext context)
    {
        _mapper = autoMapper;
        _context = context;
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
}
