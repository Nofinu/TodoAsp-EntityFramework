using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class FakeDb
    {
        private List<ToDo> _ToDos;
        public FakeDb() {
            _ToDos = new List<ToDo>() { new(0,"title","description",true) };
        }

        public List<ToDo> GetAll()
        {
            return _ToDos;
        }

        public ToDo? GetById(int id)
        {
            return _ToDos.FirstOrDefault(t => t.Id == id);
        }

        public void Add(ToDo toDo)
        {
            toDo.Id = _ToDos.Count;
            _ToDos.Add(toDo);
        }

        public bool Delete(int id)
        {
            var todo = GetById(id);

            if (todo == null)
                return false;

            _ToDos.Remove(todo);

            return true;
        }

        public bool Change(int id)
        {
            var toDo = GetById(id);
            if (toDo == null)
                return false;

            toDo.Finished = !toDo.Finished;

            return true;
        }
    }
}
