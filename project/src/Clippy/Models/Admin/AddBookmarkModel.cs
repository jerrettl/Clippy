using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class AddBookmarkModel
    {
        [Required]
        public string Location { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }
}
