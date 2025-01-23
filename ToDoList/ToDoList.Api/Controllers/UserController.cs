// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.DTOs;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // GET: api/<UserController>
    [HttpGet]
    public List<UserDTO> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new UserDTO()).ToList();
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public UserDTO Get(Guid id)
    {
        return new UserDTO();
    }

    // POST api/<UserController>
    [HttpPost]
    public void Post([FromBody] UserDTO user)
    {
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(Guid id, [FromBody] UserDTO user)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
    }
}
