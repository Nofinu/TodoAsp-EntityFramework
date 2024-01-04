using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository<ToDo> _repository;
        public ToDoController(IRepository<ToDo> repositoryTodoList)
        {
            _repository = repositoryTodoList;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Submit(ToDo todo)
        {
            ToDo todoCreated = new(title: todo.Title,description:todo.Description,status:false);
            _repository.Create(todoCreated);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _repository .Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Change(int id)
        {
            ToDo todoFind = _repository.GetById(id);
            todoFind.Finished = !todoFind.Finished;
            _repository.Update(todoFind);
            return RedirectToAction("Index");
        }

    }
}
