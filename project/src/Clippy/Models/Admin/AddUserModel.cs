using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class AddUserModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        public string Roles { get; set; }
        public string Subscriptions { get; set; }
    }
}
