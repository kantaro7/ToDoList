namespace ToDoList.Service.Services;

using Common;

using Models.InterfaceRepositories;

using System.Threading.Tasks;

using ToDoList.Service.Contracts;

public class TaskService : ITaskService
{

    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ApiResponse<List<Models.Task>>> GetAllTasks() => await _taskRepository.GetAllTasks();

    public async Task<ApiResponse<Models.Task>> GetTaskById(Guid id) => await _taskRepository.GetTaskById(id);

    public async Task<ApiResponse<Models.Task>> CreateTask(Models.Task task) => await _taskRepository.CreateTask(task);

    public async Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task) => await _taskRepository.UpdateTask(id, task);

    public async Task<ApiResponse<Models.Task>> DeleteTask(Guid id) => await _taskRepository.DeleteTask(id);
}

