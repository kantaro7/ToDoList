namespace Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public bool Status { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
