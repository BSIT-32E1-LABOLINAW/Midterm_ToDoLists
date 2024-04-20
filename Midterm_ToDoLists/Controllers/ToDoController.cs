using Microsoft.AspNetCore.Mvc;
using ToDo.Services;
using ToDo.Repository;
using ToDo.Domain;

namespace Midterm_ToDoLists.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public ActionResult Index()
        {
            var todos = _toDoService.GetAll();

            // Add numbering to the todos
            var numberedTodos = todos.Select((todo, index) =>
                new Tuple<int, ToDo.Domain.ToDo>(index + 1, todo)).ToList();

            return View(numberedTodos);
        }
    }
}