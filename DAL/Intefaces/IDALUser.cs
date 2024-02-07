using DAL.Classes;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IDALUser
    {
        Task<List<User>> GetAll();
        Task<bool> Add(User description);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, User user);
    }
}
