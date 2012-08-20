using System.ComponentModel.DataAnnotations;

namespace Bekk.dontnetintro.WebApi.Blog.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }
    }
}