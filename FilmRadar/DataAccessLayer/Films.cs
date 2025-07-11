using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Films
    {
        public int ID { get; set; }
        public string FilmName { get; set; }
        public decimal IMDB { get; set; }
        public int Category_ID { get; set; }
        public string CategoryStr { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }
        public string Topic { get; set; }
        public bool Status { get; set; }
        public string StatusStr { get; set; }

    }
}
