using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class UnionTaskContext:DbContext
    {
        public UnionTaskContext(DbContextOptions<UnionTaskContext> option): base(option)
        {
            
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
