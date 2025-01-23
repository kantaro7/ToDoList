namespace Models;

using System;
using System.Collections.Generic;

public class User
{
    public User() { }
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
    public string Token { get; set; }
    public bool Status { get; set; } = true;
    public List<Task> Tasks { get; set; }
}
