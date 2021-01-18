using BlogEntity;
using CoreBlogData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlogData
{
    public class BlogRules : IBlogRules
    {
        public List<Post> GetAllBlogs(string userId)
        {
            using(var db = new BlogContext())
            {
                List<Post> active = db.BlogPosts.Where(x => x.Pending == "N").Where(x => x.PublishDate != null)
                    .Select(x => new Post() { Id = x.Id, Author = x.Author, PostText = x.PostText, PublishDate = x.PublishDate, AllowEdit = (x.Author == userId) }).ToList();
                return active;
            }    
        }

        List<Post> IBlogRules.GetAllPendingBlogs()
        {
            using (var db = new BlogContext())
            {
                List<Post> active = db.BlogPosts.Where(x => x.Pending == "Y")
                    .Select(x => new Post() { Id = x.Id, Author = x.Author, PostText = x.PostText, PublishDate = x.PublishDate, AllowEdit = true}).ToList();
                return active;
            }
        }

        public bool SetApproveBlog(int Id)
        {
            using (var db = new BlogContext())
            {
                var exist = db.BlogPosts.Find(Id);
                if (exist != null)
                {
                    exist.Pending = "N";
                    exist.PublishDate = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

            public bool CreatePost(Post data)
        {
            bool result = false;
            try
            {
                using (var db = new BlogContext())
                {
                    db.BlogPosts.Add(new BlogPost() { Author = data.Author, EntryDate = DateTime.Now, Pending = "Y", PostText = data.PostText });
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool EditPost(Post data)
        {
            var result = false;
            return result;
        }

        public void DeletePost(int id)
        {
            using (var db = new BlogContext())
            {
                var exist = db.BlogPosts.Find(id);
                if(exist != null)
                {
                    db.BlogPosts.Remove(exist);
                    db.SaveChanges();
                }
            }
        }


        public Post GetPost(int id)
        {
            using (var db = new BlogContext())
            {
                var exist = db.BlogPosts.Find(id);
                return new Post() { Author = exist.Author, AllowEdit = false, Id = exist.Id, PostText = exist.PostText,  PublishDate = exist.PublishDate };
            }
        }

        public bool CreateComment(CommentInfo data)
        {
            var result = false;
            using(var db = new BlogContext())
            {
                db.PostComment.Add(new PostComment() { 
                    Author = data.Username,
                    BlogPostId = data.Id,
                    Comment = data.Comment,
                    PublishDate = DateTime.Now
                });
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
