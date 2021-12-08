using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_advanced.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{


    private readonly ILogger<TodoController> _logger;
    private TodoDbContext DbContext { get; set; }

    public TodoController(TodoDbContext dbContext, ILogger<TodoController> logger)
    {
        DbContext = dbContext;
        _logger = logger;
    }

    [HttpGet(Name = "GetTodos")]
    public IEnumerable<TodoItem> Get()
    {
        return DbContext.Todos.ToList();
    }

    [HttpPost(Name = "CreateTodo")]
    public IActionResult Post(string content)
    {
        DbContext.Todos.Add(new TodoItem()
        {
            Content = content
        });
        DbContext.SaveChanges();
        return Ok();
    }
}
