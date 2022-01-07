using TodoApiDB.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApiDB.Data;

class TodoDb : DbContext {
  public TodoDb(DbContextOptions options) : base(options) {}
  public DbSet<Todo> Todos {get; set;}

  protected override void onModelCreating (ModelBuilder modelBuilder) {
    
  }
}
