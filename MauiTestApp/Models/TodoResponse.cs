namespace MauiTestApp.Models;

public class TodoResponse
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}