namespace ToDoList.Api.DTOs;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateTaskDTO
{
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; } = false;
    public Guid UserId { get; set; }
}
