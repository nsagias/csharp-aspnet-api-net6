namespace TodoAPI.DB;

// Todo Model
public record Todo {
  public int Id {get; set;}
  public string? Name { get; set;}
}

public class TodoDB {
  // create mock dataList
  private static List<Todo> _todosList = new List<Todo>() {
    new Todo{ Id=1, Name="Learn minimal c# api" },
    new Todo{ Id=2, Name="Learn how the use it K8s" },
    new Todo{ Id=3, Name="Learn how to lauch on Azure" }
  };
}