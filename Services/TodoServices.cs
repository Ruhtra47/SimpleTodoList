using SimpleTodoList.Models;

namespace SimpleTodoList.Services;
public static class TodoService
{
    static List<Todo> Todos { get; }
    static int nextId = 3;
    static TodoService()
    {
        Todos = new List<Todo>{
            new Todo { Id=1, Title="Learn Blazor Pages", Done=false },
            new Todo { Id=2, Title="Create a real time chat", Done=false }
        };
    }

    public static List<Todo> GetAll() => Todos;

    public static Todo? Get(int id) => Todos.FirstOrDefault(t => t.Id == id);

    public static void Add(Todo todo)
    {
        todo.Id = nextId++;
        Todos.Add(todo);
    }

    public static void Delete(int id)
    {
        var todo = Get(id);
        if (todo is null)
            return;
        Todos.Remove(todo);
    }

    public static void SetDone(int id)
    {
        var index = Todos.FindIndex(t => t.Id == id);
        if (index == -1)
            return;
        Todos[index].Done = !Todos[index].Done;
    }

    public static void Update(Todo todo)
    {
        var index = Todos.FindIndex(t => t.Id == todo.Id);
        if (index == -1)
            return;
        Todos[index] = todo;
    }
}