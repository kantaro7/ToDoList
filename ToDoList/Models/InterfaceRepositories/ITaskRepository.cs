namespace Models.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading.Tasks;
public interface ITaskRepository
{
    Task<ApiResponse<List<Models.Task>>> GetAllTasks();
    Task<ApiResponse<Models.Task>> GetTaskById(Guid id);
    Task<ApiResponse<Models.Task>> CreateTask(Models.Task task);
    Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task);
    Task<ApiResponse<Models.Task>> DeleteTask(Guid id);
}
