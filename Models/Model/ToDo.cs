using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Model
{
    public class ToDo
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Complated { get; set; }



    }
}
