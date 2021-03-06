using System;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class User
    {
        public int Id  { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public string GithubId { get; set; }
    }
}
