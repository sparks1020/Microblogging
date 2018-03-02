using System;
using Microblogging.Database_files;


namespace Microblogging.Models
{
    public class Microblog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
    }
}
