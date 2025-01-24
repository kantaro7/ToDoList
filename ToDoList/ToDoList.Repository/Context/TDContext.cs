namespace ToDoList.Repository.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SQLEntities;

public class TDContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public TDContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public TDContext(IConfiguration configuration, DbContextOptions<TDContext> options)
            : base(options)
    {
        Configuration = configuration;
    }

    public TDContext(DbContextOptions<TDContext> options)
            : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SQLConnection"));
        }
    }
}

