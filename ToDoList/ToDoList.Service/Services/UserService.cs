namespace ToDoList.Service.Services;

using Common;

using Models.InterfaceRepositories;

using System.Threading.Tasks;

using ToDoList.Service.Contracts;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<List<Models.User>>> GetAllUsers() => await _userRepository.GetAllUsers();

    public async Task<ApiResponse<Models.User>> GetUserById(Guid id) => await _userRepository.GetUserById(id);

    public async Task<ApiResponse<Models.User>> CreateUser(Models.User user) => await _userRepository.CreateUser(user);

    public async Task<ApiResponse<Models.User>> UpdateUser(Guid id, Models.User user) => await _userRepository.UpdateUser(id, user);

    public async Task<ApiResponse<Models.User>> DeleteUser(Guid id) => await _userRepository.DeleteUser(id);
}

