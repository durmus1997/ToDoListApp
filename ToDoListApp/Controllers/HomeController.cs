using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListApp.Models;
using ToDoListApp.Models.ViewModel;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ToDoDbContext _context;

        public HomeController(ToDoDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var todos = GetAllTodos();
            return View(todos);
        }

        internal ToDoViewModel GetAllTodos()
        {
            var todos = _context.ToDos.ToList();
            return new ToDoViewModel
            {
                ToDoList = todos
            };
        }

        public RedirectResult Insert(ToDo todo)
        {
            todo.CreateDate = System.DateTime.Now;
            todo.UpdateDate = System.DateTime.Now;
            _context.ToDos.Add(todo);
            _context.SaveChanges();

            return Redirect("/");
        }
        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var todo = _context.ToDos.Find(id);
            _context.ToDos.Remove(todo);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpGet]
        public JsonResult PopulateForm(int id)
        {
            var todo = GetById(id);
            return Json(todo);
        }

        private ToDo GetById(int id)
        {
            ToDo todo = _context.ToDos.Find(id);
            return todo;
        }

        public RedirectResult Update(ToDo todo)
        {
            var todoToUpdate = _context.ToDos.Find(todo.Id);
            todoToUpdate.UpdateDate = System.DateTime.Now;
            _context.ToDos.Update(todoToUpdate);
            _context.SaveChanges();

            return Redirect("/");
        }
    }
}