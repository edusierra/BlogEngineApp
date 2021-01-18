using BlogEntity;
using CoreBlogData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiBlogController : ControllerBase
    {
        private readonly IBlogRules blogRules;
        public ApiBlogController(IBlogRules _blogRules)
        {
            blogRules = _blogRules;
        }
        // GET: api/<ApiBlogController>
        [HttpGet]
        public List<Post> GetAllPost()
        {
            return blogRules.GetAllBlogs("edusie");
        }

        // GET api/<ApiBlogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiBlogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiBlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiBlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
