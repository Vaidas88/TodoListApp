using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class TodoListService
    {
        public void AddTodoItem(TodoItemModel TodoItem)
        {
            System.IO.File.AppendAllText("todolist.txt", JsonSerializer.Serialize<TodoItemModel>(TodoItem) + "\r\n");
        }
        public List<TodoItemModel> GetAll()
        {
            string[] lines = System.IO.File.ReadAllLines("todolist.txt");

            List<TodoItemModel> TodoItemsList = new List<TodoItemModel>();

            Array.ForEach(lines, line =>
            {
                TodoItemsList.Add(JsonSerializer.Deserialize<TodoItemModel>(line));
            });

            return TodoItemsList;
        }

        public void DeleteTodoItem(int id)
        {
            string[] oldLines = System.IO.File.ReadAllLines("todolist.txt");
            string[] newLines = oldLines.Where(line => !line.StartsWith($"{{\"Id\":{id},")).ToArray();
            System.IO.File.WriteAllLines("todolist.txt", newLines);
        }
    }
}