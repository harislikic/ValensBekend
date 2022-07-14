using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_backend.Models
{
    public class Favorites
    {
        public int Id { get; set; }

        [ForeignKey(nameof(movie))]
        public int MovieID { get; set; }
        public Movies movie { get; set; }
    }
}
