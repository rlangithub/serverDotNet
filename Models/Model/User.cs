using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Model
{
    public class User
    {
        public int ID { get; set; }

        //        מזהה: (id) int, not null, pk, identity

        public string Name { get; set; }
        //שם(name) : nvarchar(50)
        public string Address { get; set; }
        //כתובת: (address) nvarchar(255)
        public string Email { get; set; }
        //מייל: (email) nvarchar(255)
        public string Phone { get; set; }
        //טלפון:(phone) nvarchar(255)

    }
}
