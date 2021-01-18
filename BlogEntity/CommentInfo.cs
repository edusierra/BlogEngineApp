using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEntity
{
    public class CommentInfo
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }

    }
}
