using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using test_backend.Models;

namespace test_backend.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(
          DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
      
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Favorites> Favorites { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
