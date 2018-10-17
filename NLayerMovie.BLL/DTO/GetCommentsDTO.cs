using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.DTO
{
    public class GetCommentsDTO
    {
        public int id { get; set; }
        public string creator { get; set; }
        public string fullname { get; set; }

        public string content { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
