namespace TodoAPI.DB;

// Todo Model
public record Todo {
  public int Id {get; set;}
  public string? Name { get; set;}
}

