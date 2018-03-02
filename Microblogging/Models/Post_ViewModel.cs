using System;
using System.ComponentModel.DataAnnotations;

namespace Microblogging.Database_files
{
    public class Post_ViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
    }
}
