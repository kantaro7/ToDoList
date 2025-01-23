﻿namespace ToDoList.Repository.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[PrimaryKey("Id")]
public class Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? CompletedDate { get; set; } = null;
    public bool Status { get; set; } = true;
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
