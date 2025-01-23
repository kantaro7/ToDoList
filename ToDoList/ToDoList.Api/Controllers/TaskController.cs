namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<TaskDTO> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new TaskDTO()).ToList();
    }

    [HttpGet("{id}")]
    public TaskDTO Get(Guid id)
    {
        return new TaskDTO();
    }

    [HttpPost]
    public TaskDTO Post([FromBody] TaskDTO task)
    {
        return task;
    }

    [HttpPut("{id}")]
    public TaskDTO Put([FromBody] Guid id, [FromBody] TaskDTO task)
    {
        return task;
    }

    [HttpDelete("{id}")]
    public TaskDTO Delete(Guid id)
    {
        return new TaskDTO();
    }
}
