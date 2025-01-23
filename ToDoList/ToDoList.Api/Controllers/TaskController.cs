namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;
using ToDoList.Service.Contracts;
using Common;
using global::AutoMapper;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public TaskController(ITaskService taskService, ILogger<TaskController> logger, IMapper mapper)
    {
        _logger = logger;
        _taskService = taskService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ApiResponse<List<TaskDTO>>> Get()
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetAllTasks();
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure))
                : new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<TaskDTO>> Get(Guid id)
    {

        try
        {
            ApiResponse<Models.Task> result = await _taskService.GetTaskById(id);
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure))
                : new ApiResponse<TaskDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpPost]
    public async Task<ApiResponse<TaskDTO>> Post([FromBody] TaskDTO task)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.CreateTask(_mapper.Map<Models.Task>(task));
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure))
                : new ApiResponse<TaskDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse<TaskDTO>> Put([FromBody] Guid id, [FromBody] TaskDTO task)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.UpdateTask(id, _mapper.Map<Models.Task>(task));
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure))
                : new ApiResponse<TaskDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse<TaskDTO>> Delete(Guid id)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.DeleteTask(id);
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure))
                : new ApiResponse<TaskDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }
}
