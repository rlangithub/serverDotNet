using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IDALToDo
    {
        Task<List<ToDo>> GetAll();
        Task<bool> Add(ToDo description);
        Task<bool> Delete(int id);
        Task<bool> Update(ToDo todo);
    }
}
