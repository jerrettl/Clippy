using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class AddBookmarkModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsFavorite { get; set; }

        public int ResourceId { get; set; }

        public string Tags { get; set; }

        public int UserId { get; set; }
    }
}
