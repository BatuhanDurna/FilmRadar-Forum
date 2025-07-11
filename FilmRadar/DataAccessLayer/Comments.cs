using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Comments
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public int User_ID { get; set; }
        public string UserStr { get; set; }
        public int Films_ID { get; set; }
        public string FilmsStr { get; set; }
        public DateTime CommentTime { get; set; }
        public int Viewcomment { get; set; }
        public bool Status { get; set; }
        public string StatusStr { get; set; }


    }
}
