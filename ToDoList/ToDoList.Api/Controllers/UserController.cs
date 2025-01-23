namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;
using ToDoList.Service.Contracts;
using Common;
using global::AutoMapper;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ApiResponse<List<UserDTO>>> Get()
    {
        try
        {
            ApiResponse<List<Models.User>> result = await _userService.GetAllUsers();
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<List<UserDTO>>(result.Code, result.Description, _mapper.Map<List<UserDTO>>(result.Structure))
                : new ApiResponse<List<UserDTO>>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<UserDTO>>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<UserDTO>> Get(Guid id)
    {

        try
        {
            ApiResponse<Models.User> result = await _userService.GetUserById(id);
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<UserDTO>(result.Code, result.Description, _mapper.Map<UserDTO>(result.Structure))
                : new ApiResponse<UserDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<UserDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpPost]
    public async Task<ApiResponse<UserDTO>> Post([FromBody] UserDTO user)
    {
        try
        {
            ApiResponse<Models.User> result = await _userService.CreateUser(_mapper.Map<Models.User>(user));
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<UserDTO>(result.Code, result.Description, _mapper.Map<UserDTO>(result.Structure))
                : new ApiResponse<UserDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<UserDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse<UserDTO>> Put([FromBody] Guid id, [FromBody] UserDTO user)
    {
        try
        {
            ApiResponse<Models.User> result = await _userService.UpdateUser(id, _mapper.Map<Models.User>(user));
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<UserDTO>(result.Code, result.Description, _mapper.Map<UserDTO>(result.Structure))
                : new ApiResponse<UserDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<UserDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse<UserDTO>> Delete(Guid id)
    {
        try
        {
            ApiResponse<Models.User> result = await _userService.DeleteUser(id);
            return result.Code is Enums.ResponsesID.Successful
                ? new ApiResponse<UserDTO>(result.Code, result.Description, _mapper.Map<UserDTO>(result.Structure))
                : new ApiResponse<UserDTO>(result.Code, result.Description, null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<UserDTO>(Enums.ResponsesID.Exception, ex.Message, null);
        }
    }
}
