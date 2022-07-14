using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_backend.ViewModels
{
    public class MoviesAddVM
    {
       
        public string Title { get; set; }
        public int DateOfRelase { get; set; }
        public string About { get; set; }
        public IFormFile MoviePicture { get; set; }

        public int Genre_id { get; set; }
        public float Rating { get; set; }
        public int Minutes { get; set; }
        public string Director { get; set; }
        public string VideoLink { get; set; }
        public string TorentLink { get; set; }

    }
}
