using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBlogData.Models
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            PostComments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public string PostText { get; set; }
        public DateTime EntryDate { get; set; }
        public string Author { get; set; }
        public string Pending { get; set; }
        public DateTime? PublishDate { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
