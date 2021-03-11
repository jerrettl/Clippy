using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class EditRoleModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
