using BlogEntity;
using CoreBlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRules blogRules;

        public BlogController(IBlogRules _blogRules)
        {
            blogRules = _blogRules;
        }

        // GET: BlogController
        public ActionResult Index()
        {
            var model = blogRules.GetAllBlogs(User.Identity.Name);
            return View(model);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new Post() { Author = User.Identity.Name };
            return View(model);
        }

        // POST: BlogController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post data)
        {
            try
            {
                data.Author = User.Identity.Name;
                blogRules.CreatePost(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [Authorize]
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

        // GET: BlogController/Approve/5
    }
}
