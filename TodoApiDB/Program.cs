using TodoApiDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Todos") ?? "Data Source=Todos.db";
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddDbContext<TodoDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSqlite<TodoDb>(connectionString);
builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1", new OpenApiInfo {
    Title = "Todo API EntityFramework Core",
    Description = "API with Database",
    Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API EntityFramework V1");
});

// home
app.MapGet("/", () => "Hello World!");
// get all todos
app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync());
// create new tody
app.MapPost("/todos", async (TodoDb db, Todo todo) => {
  await db.Todos.AddAsync(todo);
  await db.SaveChangesAsync();
  return Results.Created($"/todos/{todo.Id}", todo);
});

// Update one item
app.MapPut("/todos/{id}", async (TodoDb db, Todo updateTodo, int id) => {
  var todo = await db.Todos.FindAsync(id);
  if (todo is null) return Results.NotFound();
  todo.Name = updateTodo.Name;
  todo.Description = updateTodo.Description;
  await db.SaveChangesAsync();
  return Results.NoContent();
});


// Delete one items
app.MapDelete("/todos/{id}", async (TodoDb db, int id ) => {
  var todo = await db.Todos.FindAsync(id);
  if (todo is null) return Results.NotFound();
  db.Todos.Remove(todo);
  await db.SaveChangesAsync();
  return Results.Ok();
});
app.Run();
