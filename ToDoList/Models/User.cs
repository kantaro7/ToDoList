namespace Models;

using Common;

using System;
using System.Collections.Generic;

public class User
{
    public User() { }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Enums.Roles Role { get; set; }
    public bool Status { get; set; } = true;
    public List<Task> Tasks { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }
}
