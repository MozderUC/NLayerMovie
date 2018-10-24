using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.DTO
{
    public class EditCommentDTO
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime modified { get; set; }
    }
}
