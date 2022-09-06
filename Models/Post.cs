using Dapper.Contrib.Extensions;

namespace Blog.Repositories
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}