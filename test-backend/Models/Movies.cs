using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_backend.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DateOfRelase { get; set; }
        public string About { get; set; }
        public string MoviePicture { get; set; }

        public float Rating { get; set; }
        public int Minutes { get; set; }
        public string Director { get; set; }
        public string VideoLink { get; set; }
        public string TorentLink { get; set; }
        [ForeignKey(nameof(MovieGenre))]
        public int? MovieGenre_id { get; set; }
        public MovieGenre MovieGenre { get; set; }


    }
}
