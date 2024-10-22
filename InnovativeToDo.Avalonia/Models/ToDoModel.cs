using System;
using SQLite;

namespace InnovativeToDo.Avalonia.Models;

public class ToDoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}