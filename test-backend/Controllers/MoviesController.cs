using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using test_backend.Data;
using test_backend.Models;
using test_backend.ViewModels;

namespace test_backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public MoviesController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpPost]
        public IActionResult AddMovie([FromForm] MoviesAddVM x)
        {
            var newMovie = new Movies()
            {
                Title = x.Title,
                DateOfRelase = x.DateOfRelase,
                About = x.About,
                MoviePicture = "empty.jpg",
                MovieGenre_id = x.Genre_id,
                Rating = x. Rating,
                Minutes =x.Minutes,
                Director = x.Director,
                VideoLink = x.VideoLink,
                TorentLink = x.TorentLink
            };

            if (x.MoviePicture != null)
            {
                string ekstenzija = Path.GetExtension(x.MoviePicture.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.MoviePicture.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                newMovie.MoviePicture = "https://localhost:44300/" + "uploads/" + filename;
            }
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
            return Ok(newMovie);
        }
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromForm] MoviesUpdateAddVM x)
        {
            Movies movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return BadRequest("no movie with id:" + id);

            movie.Title = x.Title;
            movie.DateOfRelase = x.DateOfRelase;
            movie.About = x.About;
            movie.MovieGenre_id = x.Genre_id;
            movie.Rating = x.Rating;
            movie.Minutes = x.Minutes;
            movie.Director = x.Director;
            movie.VideoLink = x.VideoLink;
            movie.TorentLink = x.TorentLink;
            if (x.MoviePicture != null)
            {
                string ekstenzija = Path.GetExtension(x.MoviePicture.FileName);
                var filename = $"{Guid.NewGuid()}{ekstenzija}";
                x.MoviePicture.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                movie.MoviePicture = "https://localhost:44300/" + "uploads/" + filename;
            }
            _dbContext.SaveChanges();
            return Ok(movie);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
                return BadRequest("No movie with:" + id+" id.");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return Ok(movie);
        }
        [HttpGet]
        public ActionResult<List<Movies>> GetAllMovies()
        {
            var data = _dbContext.Movies.Include(x=>x.MovieGenre).ToList();
            return data;
        }
        
        [HttpGet]
        public IActionResult GetMovieName(string name)
        {
            var movie = _dbContext.Movies.Include(x => x.MovieGenre).Where(x => x.Title.StartsWith(name));
            if(movie==null)
            {
                return BadRequest("No movie with that name");
            }
            return Ok(movie);
        }
        [HttpGet]
        public IActionResult GetMovieid(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return BadRequest("No movie with that name");
            }
            return Ok(movie);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieByCategoryName(string name)
        {
            var data = _dbContext.Movies.Where(x => x.MovieGenre.GenreName == name).ToList();
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetByGenreName( string genre)
        {
            List<Movies> movieS = _dbContext.Movies
                .Where(x=>x.MovieGenre.GenreName==genre).Include(x=>x.MovieGenre).ToList();
            if (movieS == null)
            {
                return BadRequest("No movie with that name");
            }
            return Ok(movieS);
        }


        [HttpGet]
        public IActionResult sort(string value)
        {

            if (value == "name")
                return Ok(_dbContext.Movies.Include(x => x.MovieGenre).OrderByDescending(x => x.Title).ThenByDescending(s => s.Title).ToList());
            if (value == "year")
                return Ok(_dbContext.Movies.Include(mg => mg.MovieGenre).OrderBy(x => x.DateOfRelase).ToList());
            else return Ok("error");
        }

    }
}
