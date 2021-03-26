using System;
using System.Collections.Generic;
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

        public string AvatarUrl { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        public IList<User> Subscriptions { get; set; }

        public IList<User> Followers { get; set; }

        public IList<Role> Roles { get; set; }

        public User()
        {
            Followers = new List<User>();
            Roles = new List<Role>();
            Subscriptions = new List<User>();
        }
    }
}
