using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity
{
    public class Post
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Author { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool AllowEdit { get; set; }
    }
}
