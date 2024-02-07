using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IDALPost
    {
        Task<List<Post>> GetAll();
        Task<bool> Add(Post description);
        Task<bool> Delete(int id);
        Task<bool> Update(Post post);
    }
}
