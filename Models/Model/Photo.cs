using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Photo
    {
        public int ID { get; set; }
        //מזהה(id): int, not null, pk, identity
        public string ImgUrl { get; set; }
        //imgUrl :nvarchar(max)

    }
}
