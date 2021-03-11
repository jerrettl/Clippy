using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Entities
{
    public class Role
    {
        public int Id  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<User> Users { get; set; }
    }
}
