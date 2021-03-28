using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models
{
    public class EditUserModel
    {
        [MaxLength(1000)]
        public string Bio { get; set; }

        public bool ClippyMode { get; set; }
    }
}
