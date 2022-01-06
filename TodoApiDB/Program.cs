using TodoApiDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<TodoDb>(options => options.UseInMemoryDatabase("items"));
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

app.MapGet("/", () => "Hello World!");
app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync());

app.Run();
