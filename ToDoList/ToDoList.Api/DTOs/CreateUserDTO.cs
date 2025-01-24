namespace ToDoList.Api.DTOs;

using Common;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class CreateUserDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [EnumDataType(typeof(Enums.Roles))]
    public Enums.Roles Role { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
