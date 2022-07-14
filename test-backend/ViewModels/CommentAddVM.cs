using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_backend.ViewModels
{
    public class CommentAddVM
    {
        public string Comment { get; set; }
        public int User_id { get; set; }
        public int Movies_id { get; set; }
        public DateTime Date { get; set; }
    }
}
