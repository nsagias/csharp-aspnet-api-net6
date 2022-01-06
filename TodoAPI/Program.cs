using TodoAPI.DB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
  });
builder.Services.AddCors(options => {});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
  {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nick API V1");
  });

app.UseCors("some unique string");
app.MapGet("/", () => "This is home");

app.MapGet("/todos/{id}", (int id) => TodoDB.GetTodo(id));
app.MapGet("/todos", () => TodoDB.GetTodos());
app.MapPost("/todos", (Todo todo) => TodoDB.CreateTodo(todo));
app.MapPut("/todos", (Todo todo) => TodoDB.UpdateTodo(todo));
app.MapDelete("/todos/{id}", (int id) => TodoDB.DeleteTodo(id));

app.Run();
