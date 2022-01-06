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
    new Todo{ Id=3, Name="Learn how to launch on Azure" }
  };

  //  function to get all todo list
  public static List<Todo> GetTodos() {
    return _todosList;
  }

  //  get one
  public static Todo? GetTodo(int id) {
    return _todosList.SingleOrDefault(todo => todo.Id == id);
  }

  public static Todo CreateTodo(Todo todo) {
    _todosList.Add(todo);
    return todo;
  }

  public static Todo UpdateTodo(Todo update) {
    _todosList = _todosList.Select(todo => {
      if (todo.Id == update.Id) {
        todo.Name = update.Name;
      }
      return todo;
    }).ToList();
    return update;
  }

  // delete by ID
  public static void DeleteTodo(int id) {
    _todosList = _todosList.FindAll(todo => todo.Id != id).ToList();
  }
  
}