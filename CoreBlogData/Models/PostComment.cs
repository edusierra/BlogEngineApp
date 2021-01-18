using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBlogData.Models
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
