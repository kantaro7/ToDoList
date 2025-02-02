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
    [Required]
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [EnumDataType(typeof(Enums.Roles))]
    public Enums.Roles Role { get; set; }
    public bool Status { get; set; } = true;
    [JsonIgnore]
    public virtual ICollection<TaskDTO> Tasks { get; set; }
    public string Token { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}
