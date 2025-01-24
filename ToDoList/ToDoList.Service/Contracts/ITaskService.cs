namespace ToDoList.Service.Contracts;

using Common;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskService
{
    Task<ApiResponse<List<Models.Task>>> GetAllTasks();
    Task<ApiResponse<List<Models.Task>>> GetTasksByUser(Guid userId);
    Task<ApiResponse<List<Models.Task>>> GetPendingTasksByUser(Guid userId);
    Task<ApiResponse<List<Models.Task>>> GetCompletedTasksByUser(Guid userId);
    Task<ApiResponse<List<Models.Task>>> GetPendingTasks();
    Task<ApiResponse<List<Models.Task>>> GetCompletedTasks();
    Task<ApiResponse<Models.Task>> CompleteTaskByUser(Guid taskId, Guid userId);
    Task<ApiResponse<Models.Task>> CompleteTask(Guid taskId);
    Task<ApiResponse<Models.Task>> GetTaskById(Guid id);
    Task<ApiResponse<Models.Task>> CreateTask(Models.Task task);
    Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task);
    Task<ApiResponse<Models.Task>> UpdateTaskByUser(Guid userId, string name, Guid taskId);
    Task<ApiResponse<Models.Task>> DeleteTask(Guid id);
    Task<ApiResponse<Models.Task>> DeleteTaskByUser(Guid taskId, Guid userId);
}