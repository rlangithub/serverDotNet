using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Post
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool Like { get; set; }
        

    }
}
