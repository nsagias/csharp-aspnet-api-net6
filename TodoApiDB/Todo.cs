using Microsoft.EntityFrameworkCore;

namespace TodoApiDB.Models {
  public class Todo {
    public int Id { get; set; }
    public string? Name { get; set;}
    public string? Description {get; set;}
  }

  class TodoDB : DbContext {
    public TodoDB(DbContextOptions options) : base(options) {}
    public DbSet<Todo> Todos {get; set;}
  }
}