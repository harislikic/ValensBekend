using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class MovieGenreController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public MovieGenreController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpPost]
        public IActionResult AddGenre([FromForm] MovieGenreAddVM x)
        {
            var newGenre = new MovieGenre()
            {
                GenreName = x.GenreName,
            };

            _dbContext.MovieGenre.Add(newGenre);
            _dbContext.SaveChanges();
            return Ok(newGenre);
        }
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromForm] MovieGenreAddVM x)
        {
            MovieGenre movieGenre = _dbContext.MovieGenre.FirstOrDefault(x => x.Id == id);
            if (movieGenre == null)
                return BadRequest("no movie with id:" + id);

            movieGenre.GenreName = x.GenreName;
            _dbContext.SaveChanges();
            return Ok(movieGenre);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genremovie = _dbContext.MovieGenre.Find(id);
            if (genremovie == null)
                return BadRequest("No movie with:" + id + " id.");

            _dbContext.MovieGenre.Remove(genremovie);
            _dbContext.SaveChanges();
            return Ok(genremovie);
        }
        [HttpGet]
        public IActionResult GetAllCategorys()
        {
            var data = _dbContext.MovieGenre.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var data = _dbContext.MovieGenre.Where(x=>x.Id==id).ToList();
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetCategoryByName(string name)
        {
            var data = _dbContext.MovieGenre.Where(x => x.GenreName == name).ToList();
            return Ok(data);
        }
    }
}
