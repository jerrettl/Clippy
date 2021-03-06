using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class EditUserModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
