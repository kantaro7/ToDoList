namespace ToDoList.Api.DTOs;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateTaskDTO
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool IsComplete { get; set; } = false;
    [Required]
    public Guid UserId { get; set; }
}
