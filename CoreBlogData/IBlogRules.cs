using BlogEntity;
using System;
using System.Collections.Generic;

namespace CoreBlogData
{
    public interface IBlogRules
    {
        List<Post> GetAllBlogs(string userId);
        List<Post> GetAllPendingBlogs();
        bool SetApproveBlog(int Id);
        bool CreatePost(Post data);
        bool EditPost(Post data);
        void DeletePost(int id);
        Post GetPost(int id);
        bool CreateComment(CommentInfo data);
    }
}
