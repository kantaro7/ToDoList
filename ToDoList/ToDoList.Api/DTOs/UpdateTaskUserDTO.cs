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

public class UpdateTaskUserDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public Guid TaskId { get; set; }
}
