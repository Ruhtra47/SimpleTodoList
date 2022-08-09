using System.ComponentModel.DataAnnotations;

namespace SimpleTodoList.Models;

public class Todo
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }
    public bool Done { get; set; }
}