using DAL.Intefaces;
using Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DAL.Classes
{
    public class DALToDo: IDALToDo
    {
        private readonly UnionTaskContext _unionTaskContext;
        public DALToDo(UnionTaskContext UnionTaskContext)
        {
            _unionTaskContext = UnionTaskContext;
        }
        public async Task<List<ToDo>> GetAll()
        {
            List<ToDo> todos = await _unionTaskContext.ToDos.ToListAsync();
            return todos;
        }
        public async Task<bool> Add(ToDo description)
        {
            ToDo todo = description;
            await _unionTaskContext.ToDos.AddAsync(todo);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idTodo = _unionTaskContext.ToDos.FirstOrDefault(x => x.ID == id);
            _unionTaskContext.ToDos.Remove(idTodo);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(ToDo todo)
        {
            var idTodo = _unionTaskContext.ToDos.FirstOrDefault(x => x.ID == todo.ID);
            if (idTodo == null)
            {
                return false;
            }
            
            idTodo.Name = todo.Name;
            idTodo.Complated = todo.Complated;
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

   


    }
}
