using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clippy.Entities {
    public class Resource {
        public int Id  { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Location { get; set; }

        [NotMapped]
        public Dictionary<string,string> Metadata { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
