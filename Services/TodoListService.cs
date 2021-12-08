using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class TodoListService
    {
        public void AddTodoItem(TodoItemModel TodoItem)
        {
            string line = TodoItem.Id + "|" + TodoItem.Name + "|" + TodoItem.Description + "\r\n";

            System.IO.File.AppendAllText("todolist.txt", line);
        }
        public List<TodoItemModel> GetAll()
        {
            string[] lines = System.IO.File.ReadAllLines("todolist.txt");
            List<TodoItemModel> TodoItemsList = new List<TodoItemModel>();

            Array.ForEach(lines, line =>
            {
                string[] lineValues = line.Split("|");
                TodoItemsList.Add(new TodoItemModel
                {
                    Id = Convert.ToInt32(lineValues[0]),
                    Name = lineValues[1],
                    Description = lineValues[2]
                });
            });

            return TodoItemsList;
        }

        public void DeleteTodoItem(string id)
        {
            string[] oldLines = System.IO.File.ReadAllLines("todolist.txt");
            string[] newLines = oldLines.Where(line => !line.StartsWith(id + "|")).ToArray();
            System.IO.File.WriteAllLines("todolist.txt", newLines);
        }
    }
}