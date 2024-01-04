using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ToDoRepository : IRepository<ToDo>
    {
        private readonly ApplicationDbContext _db;

        public ToDoRepository(ApplicationDbContext db)
        {
             _db = db;
        }
        public bool Create(ToDo entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var a = _db.todos.Find(id);
            if(a != null)
            {
                _db.todos.Remove(a);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ToDo> GetAll()
        {
            return _db.todos.ToList();
        }

        public ToDo GetById(int id)
        {
            return _db.todos.Find(id);
        }

        public bool Update(ToDo entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
            return true;
        }
    }
}
