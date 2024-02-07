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
    public class DALPhoto: IDALPhoto
    {
        private readonly UnionTaskContext _unionTaskContext;
        public DALPhoto(UnionTaskContext UnionTaskContext)
        {
            _unionTaskContext = UnionTaskContext;
        }
        public async Task<List<Photo>> GetAll()
        {
            List<Photo> photos = await _unionTaskContext.Photos.ToListAsync();
            return photos;
        }
        public async Task<bool> Add(Photo description)
        {
            Photo photo = description;
            await _unionTaskContext.Photos.AddAsync(photo);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idPhoto = _unionTaskContext.Photos.FirstOrDefault(x => x.ID == id);
            _unionTaskContext.Photos.Remove(idPhoto);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

    }
}
