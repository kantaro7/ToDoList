namespace ToDoList.Service.Services;

using Common;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using Models;
using Models.InterfaceRepositories;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using ToDoList.Service.Contracts;

using static Common.Enums;

public class AuthenticationService : IAuthenticationService
{

    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationService(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
    {
        _authenticationRepository = authenticationRepository;
        _configuration = configuration;
    }

    public async Task<ApiResponse<Models.User>> Login(Models.Login data)
    {
        ApiResponse<User> result = await _authenticationRepository.Login(data);

        if (result.Code == Enums.ResponsesID.Successful)
            result.Structure.Token =  GenerateToken(result.Structure);

        return result;
    }
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["PrivateKey"]);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials,
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        claims.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(Roles), user.Role)));

        return claims;
    }
}

