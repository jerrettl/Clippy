using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class Bookmark
    {
        public int Id  { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public IList<Tag> Tags { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
