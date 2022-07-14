using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_backend.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
      

 

        [ForeignKey(nameof(movies))]
        public int Movies_id { get; set; }
        public Movies movies { get; set; }
        public DateTime Date { get; set; }


    }
}
