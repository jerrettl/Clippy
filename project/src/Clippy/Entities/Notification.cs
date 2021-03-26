using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
