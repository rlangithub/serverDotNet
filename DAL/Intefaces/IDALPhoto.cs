using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IDALPhoto
    {
        Task<List<Photo>> GetAll();
        Task<bool> Add(Photo description);
        Task<bool> Delete(int id);
    }
}
