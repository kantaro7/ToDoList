namespace ToDoList.Service.Contracts;

using Common;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskService
{
    Task<ApiResponse<List<Models.Task>>> GetAllTasks();
    Task<ApiResponse<Models.Task>> GetTaskById(Guid id);
    Task<ApiResponse<Models.Task>> CreateTask(Models.Task task);
    Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task);
    Task<ApiResponse<Models.Task>> DeleteTask(Guid id);
}