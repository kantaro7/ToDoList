namespace ToDoList.Repository.Context;

using Microsoft.EntityFrameworkCore;

using SQLEntities;

public class TDContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
}

