using BlogEntity;
using CoreBlogData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IBlogRules blogRules;

        public CommentController(IBlogRules _blogRules)
        {
            blogRules = _blogRules;
        }
        // GET: CommentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create(int id)
        {
            var post = blogRules.GetPost(id);
            var model = new CommentInfo()
            {
                Id = post.Id,
                Post = post.PostText,
                Published = (DateTime)post.PublishDate,
                Author = post.Author,
                Username = User.Identity.Name
            };
            return View(model);
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentInfo data)
        {
            try
            {
                if(blogRules.CreateComment(data))
                {
                    return RedirectToAction("Index", "Blog");
                }
            }
            catch
            {
            }
            return View(data);
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
