using DAL.Intefaces;
using Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class DALUser : IDALUser
    {
        private readonly UnionTaskContext _unionTaskContext;
        public DALUser(UnionTaskContext UnionTaskContext)
        {
            _unionTaskContext = UnionTaskContext;
        }
        public async Task<List<User>> GetAll()
        {
            List<User> users = await _unionTaskContext.Users.ToListAsync();
            return users;
        }
        public async Task<bool> Add(User description)
        {
            User user = description;
            await _unionTaskContext.Users.AddAsync(user);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idUser = _unionTaskContext.Users.FirstOrDefault(x => x.ID == id);
            _unionTaskContext.Users.Remove(idUser);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(int id, User user)
        {
            var idUser = _unionTaskContext.Users.FirstOrDefault(x => x.ID == id);
            if (idUser == null)
            {
                return false;
            }
            idUser.Address = user.Address;
            idUser.Name = user.Name;
            idUser.Email = user.Email;
            idUser.Phone = user.Phone;
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        //public async Task<bool> UpdateComplete(int id)
        //{
        //    var idUser = _unionTaskContext.Todos.FirstOrDefault(x => x.Id == id);
        //    if (idUser == null)
        //    {
        //        return false;
        //    }
        //    idUser.Complated = !idUser.Complated;
        //    var isOk = _unionTaskContext.SaveChanges() > 0;
        //    return isOk;
        //}

    }
}
