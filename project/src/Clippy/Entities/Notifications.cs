using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class Notifications
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
