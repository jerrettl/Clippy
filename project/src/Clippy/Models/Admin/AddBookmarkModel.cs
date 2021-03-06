using Clippy.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class AddBookmarkModel
    {
        [Required]
        public string Url { get; set; }

        public string Title { get; set; }
    }
}
