namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;
using ToDoList.Service.Contracts;
using Common;
using global::AutoMapper;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, ILogger<UserController> logger, IMapper mapper)
    {
        _logger = logger;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<ApiResponse<UserDTO>> Login([FromBody] LoginDTO data)
    {
        try
        {
            ApiResponse<Models.User> result = await _authenticationService.Login(_mapper.Map<Models.Login>(data));
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
