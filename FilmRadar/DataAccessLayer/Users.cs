using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FavoriteFilm { get; set; }
        public string Occupation { get; set; }
        public int UserType_ID { get; set; }
        public string UserTypeStr { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string StatusStr { get; set; }

    }
}
