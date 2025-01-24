namespace ToDoList.Api.DTOs;

using Common;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class UpdateUserDTO
{
    [Required]
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [EnumDataType(typeof(Enums.Roles))]
    public Enums.Roles Role { get; set; }
    [MinLength(6)]
    [AllowNull]
    public string Password { get; set; }
}
