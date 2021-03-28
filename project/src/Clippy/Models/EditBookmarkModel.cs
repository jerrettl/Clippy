using System.ComponentModel.DataAnnotations;

namespace Clippy.Models
{
    public class EditBookmarkModel
    {
        public int Id { get; set; }
        
        public string Location { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public bool IsPublic { get; set; }

        public bool Favorited { get; set; }
    }
}