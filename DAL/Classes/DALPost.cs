using DAL.Intefaces;
using Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class DALPost: IDALPost
    {

        private readonly UnionTaskContext _unionTaskContext;
        public DALPost(UnionTaskContext UnionTaskContext)
        {
            _unionTaskContext = UnionTaskContext;
        }
        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _unionTaskContext.Posts.ToListAsync();
            return posts;
        }
        public async Task<bool> Add(Post description)
        {
            Post post = description;
            await _unionTaskContext.Posts.AddAsync(post);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idPost = _unionTaskContext.Posts.FirstOrDefault(x => x.ID == id);
            _unionTaskContext.Posts.Remove(idPost);
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(Post post)
        {
            var idPost = _unionTaskContext.Posts.FirstOrDefault(x => x.ID == post.ID);
            if (idPost == null)
            {
                return false;
            }
            idPost.Content = post.Content;
            idPost.Like = post.Like;
            var isOk = _unionTaskContext.SaveChanges() > 0;
            return isOk;
        }


    }
}
