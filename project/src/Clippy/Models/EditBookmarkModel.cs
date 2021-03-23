using System.ComponentModel.DataAnnotations;

namespace Clippy.Models
{
    public class EditBookmarkModel
    {
        public int Id { get; set; }
        
        public string Location { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}