namespace ToDoList.Service.Services;

using Common;

using Models.InterfaceRepositories;

using System.Threading.Tasks;

using ToDoList.Service.Contracts;

public class TaskService : ITaskService
{

    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;


    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;        _userRepository = userRepository;

    }

    public async Task<ApiResponse<List<Models.Task>>> GetAllTasks() => await _taskRepository.GetAllTasks();

    public async Task<ApiResponse<Models.Task>> GetTaskById(Guid id) => await _taskRepository.GetTaskById(id);

    public async Task<ApiResponse<Models.Task>> CreateTask(Models.Task task) => await _taskRepository.CreateTask(task);

    public async Task<ApiResponse<Models.Task>> UpdateTask(Guid id, Models.Task task) => await _taskRepository.UpdateTask(id, task);

    public async Task<ApiResponse<Models.Task>> DeleteTask(Guid id) => await _taskRepository.DeleteTask(id);

    public async Task<ApiResponse<List<Models.Task>>> GetTasksByUser(Guid userId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<List<Models.Task>>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.GetTasksByUser(userId);
    }

    public async Task<ApiResponse<List<Models.Task>>> GetPendingTasksByUser(Guid userId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<List<Models.Task>>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.GetPendingTasksByUser(userId);
    }

    public async Task<ApiResponse<List<Models.Task>>> GetCompletedTasksByUser(Guid userId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<List<Models.Task>>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.GetCompletedTasksByUser(userId);
    }

    public async Task<ApiResponse<List<Models.Task>>> GetPendingTasks() => await _taskRepository.GetPendingTasks();
    public async Task<ApiResponse<List<Models.Task>>> GetCompletedTasks() => await _taskRepository.GetCompletedTasks();

    public async Task<ApiResponse<Models.Task>> CompleteTaskByUser(Guid taskId, Guid userId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.CompleteTaskByUser(taskId, userId);
    }

    public async Task<ApiResponse<Models.Task>> CompleteTask(Guid taskId) => await _taskRepository.CompleteTask(taskId);

    public async Task<ApiResponse<Models.Task>> UpdateTaskByUser(Guid userId, string name, Guid taskId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.UpdateTaskByUser(userId, name, taskId);
    }

    public async Task<ApiResponse<Models.Task>> DeleteTaskByUser(Guid taskId, Guid userId)
    {
        ApiResponse<Models.User> exist = await _userRepository.GetUserById(userId);
        return exist.Code != Enums.ResponsesID.Successful
            ? new ApiResponse<Models.Task>(Enums.ResponsesID.NotFound, "Usuario no encontrado", null)
            : await _taskRepository.DeleteTaskByUser(taskId, userId);
    }
}

