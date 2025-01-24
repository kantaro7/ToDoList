namespace ToDoList.Api.DTOs;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class LoginDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
