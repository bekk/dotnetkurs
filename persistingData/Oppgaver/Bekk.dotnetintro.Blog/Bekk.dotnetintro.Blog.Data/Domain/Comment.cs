namespace Bekk.dotnetintro.Blog.Data.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BlogPostId { get; set; }
    }
}