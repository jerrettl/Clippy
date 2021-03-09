using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class Tag
    {
        public int Id  { get; set; }

        [Required]
        public int BookmarkId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }
    }
}
