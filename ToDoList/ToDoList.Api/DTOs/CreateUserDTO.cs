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
    public string Name { get; set; }
    public string Email { get; set; }
    public Enums.Roles Role { get; set; }
    public string Password { get; set; }
}
