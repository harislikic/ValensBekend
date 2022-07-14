using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_backend.Data;
using test_backend.Models;
using test_backend.ViewModels;

namespace test_backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CommentsController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Comment.Where(x => x.Movies_id == id));
        }

        [HttpGet]
        public IActionResult GetCommentforMovie(string name)
        {
            var comment = _dbContext.Comment.Where(x => x.movies.Title == name);
            if (comment == null)
            {
                return BadRequest("No movie with that name");
            }

            return Ok(comment);
        }
        [HttpPost]
        public Comments Add([FromBody] CommentAddVM x)
        {
            var newcoment = new Comments()
            {
                Comment = x.Comment,           
                Movies_id = x.Movies_id,
                Date = DateTime.Now

            };
            _dbContext.Comment.Add(newcoment);
            _dbContext.SaveChanges();
            return newcoment;
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] CommentAddVM x)
        {
            Comments coment = _dbContext.Comment.FirstOrDefault(s => s.Id == id);
            if (coment == null)
                return BadRequest("Wrong id");
            coment.Comment = x.Comment;
            _dbContext.SaveChanges();
            return Get(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Comments coment = _dbContext.Comment.Find(id);
            if (coment == null)
                return BadRequest("Wrong id");

            _dbContext.Remove(coment);
            _dbContext.SaveChanges();
            return Ok(coment);
        }

        [HttpGet]
        public ActionResult<List<Comments>> GetAll()
        {
            var data = _dbContext.Comment.ToList();
            return data;
        }

    }
}
