using Microsoft.EntityFrameworkCore;

namespace aspnetcore_advanced.Controllers;

public class TodoItem
{
    public int Id { get; set; }
    public string Content { get; set; }
}

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<TodoItem> Todos => Set<TodoItem>();
}