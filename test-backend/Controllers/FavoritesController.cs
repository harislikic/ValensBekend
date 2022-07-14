using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_backend.Data;
using test_backend.Models;

namespace test_backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        public FavoritesController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Favorites.Include(x => x.movie).ToList());
        }

        [HttpPost("{id}")]
        public IActionResult Add(int id)
        {
            Favorites movie  = _dbContext.Favorites.FirstOrDefault(a => a.MovieID == id);
            if (movie != null) return BadRequest("Alredy have that movie in favorites");

            var newFav = new Favorites()
            {
                MovieID = id

            };
            _dbContext.Add(newFav);
            _dbContext.SaveChanges();
            return Ok(newFav);
        }



        [HttpDelete]
        public bool Delete(int idS)
        {

            Favorites movie = _dbContext.Favorites.FirstOrDefault(s => s.MovieID == idS);

            if (movie == null)
                return false;

            _dbContext.Remove(movie);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
