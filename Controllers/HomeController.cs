using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoListService _todoListService;

        public HomeController(ILogger<HomeController> logger, TodoListService todoListService)
        {
            _logger = logger;
            _todoListService = todoListService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("TodoItemsList");
        }

        public IActionResult TodoItemsList()
        {
            List<TodoItemModel> TodoItemsList = _todoListService.GetAll();

            return View(TodoItemsList);
        }

        public IActionResult AddNewTodo()
        {
            return View();
        }

        public IActionResult DeleteTodoItem(string id)
        {
            _todoListService.DeleteTodoItem(id);
            return RedirectToAction("TodoItemsList");
        }

        public IActionResult PostNewTodo(TodoItemModel TodoItem)
        {
            if (Request.Method == "POST" && !String.IsNullOrEmpty(TodoItem.Name) && !String.IsNullOrEmpty(TodoItem.Description))
            {
                _todoListService.AddTodoItem(TodoItem);
            }

            return RedirectToAction("AddNewTodo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
