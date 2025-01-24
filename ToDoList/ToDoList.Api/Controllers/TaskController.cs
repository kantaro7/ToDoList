namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;
using ToDoList.Service.Contracts;
using Common;
using global::AutoMapper;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpGet("getAllTasks")]
    public async Task<ActionResult> GetAllTasks()
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetAllTasks();
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpGet("getTasksByUser")]
    public async Task<ActionResult> GetTasksByUser([FromQuery] Guid userId)
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetTasksByUser(userId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpGet("getPendingTasksByUser")]
    public async Task<ActionResult> GetPendingTasksByUser([FromQuery] Guid userId)
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetPendingTasksByUser(userId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpGet("getCompletedTasksByUser")]
    public async Task<ActionResult> GetCompletedTasksByUser([FromQuery] Guid userId)
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetCompletedTasksByUser(userId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpGet("getPendingTasks")]
    public async Task<ActionResult> GetPendingTasks()
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetPendingTasks();
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpGet("getCompletedTasks")]
    public async Task<ActionResult> GetCompletedTasks()
    {
        try
        {
            ApiResponse<List<Models.Task>> result = await _taskService.GetCompletedTasks();
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, _mapper.Map<List<TaskDTO>>(result.Structure)))
                : BadRequest(new ApiResponse<List<TaskDTO>>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<TaskDTO>>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {

        try
        {
            ApiResponse<Models.Task> result = await _taskService.GetTaskById(id);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateTaskDTO task)
    {
        try
        {   TaskDTO newTask = new() { Id = new Guid(), Name=task.Name, IsComplete= task.IsComplete, CreatedDate= DateTime.Now, Status = true, UserId = task.UserId };
            ApiResponse<Models.Task> result = await _taskService.CreateTask(_mapper.Map<Models.Task>(newTask));
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] TaskDTO task)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.UpdateTask(id, _mapper.Map<Models.Task>(task));
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpPut("updateTaskByUser")]
    public async Task<ActionResult> UpdateTaskByUser([FromBody] UpdateTaskUserDTO data)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.UpdateTaskByUser(data.UserId, data.Name, data.TaskId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpPut("completeTask")]
    public async Task<ActionResult> CompleteTask([FromBody] Guid taskId)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.CompleteTask(taskId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpPut("completeTaskByUser")]
    public async Task<ActionResult> CompleteTaskByUser([FromBody] TaskUserDTO data) 
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.CompleteTaskByUser(data.TaskId, data.UserId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = nameof(Enums.Roles.Admin))]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.DeleteTask(id);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }

    [Authorize(Roles = $"{nameof(Enums.Roles.Admin)},{nameof(Enums.Roles.Standard)}")]
    [HttpDelete("deleteTaskByUser")]
    public async Task<ActionResult> DeleteTaskByUser([FromBody] TaskUserDTO data)
    {
        try
        {
            ApiResponse<Models.Task> result = await _taskService.DeleteTaskByUser(data.TaskId, data.UserId);
            return result.Code is Enums.ResponsesID.Successful
                ? Ok(new ApiResponse<TaskDTO>(result.Code, result.Description, _mapper.Map<TaskDTO>(result.Structure)))
                : result.Code is Enums.ResponsesID.NotFound
                    ? NotFound(new ApiResponse<TaskDTO>(result.Code, result.Description, null))
                    : BadRequest(new ApiResponse<TaskDTO>(result.Code, result.Description, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TaskDTO>(Enums.ResponsesID.Exception, ex.Message, null));
        }
    }
}
