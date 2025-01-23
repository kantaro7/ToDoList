namespace ToDoList.Repository.Context;

using Microsoft.EntityFrameworkCore;

using ToDoList.Repository.Entities;

public class TDContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=GRAYBOOK\\SQL2022;Database=ToDoDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
}

