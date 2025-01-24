namespace ToDoList.Api.DTOs;

using Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class TaskUserDTO
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid TaskId { get; set; }
}
