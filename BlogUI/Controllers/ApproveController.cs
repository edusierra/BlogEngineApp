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
    [Authorize]
    public class ApproveController : Controller
    {
        private readonly IBlogRules blogRules;

        public ApproveController(IBlogRules _blogRules)
        {
            blogRules = _blogRules;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = blogRules.GetAllPendingBlogs();
            return View(model);
        }

        // POST: BlogController/Approve/5
        [Authorize]
        [HttpPost]
        public ActionResult Approve(int Id)
        {
            try
            {
                blogRules.SetApproveBlog(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: BlogController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            blogRules.DeletePost(id);
            return RedirectToAction("Approve");
        }
    }
}
