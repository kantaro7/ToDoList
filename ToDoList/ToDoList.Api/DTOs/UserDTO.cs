﻿namespace ToDoList.Api.DTOs;

using Common;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Enums.Roles Role { get; set; }
    public bool Status { get; set; } = true;
    [JsonIgnore]
    public virtual ICollection<TaskDTO> Tasks { get; set; }
    public string Token { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}
