using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class EditResourceModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Location { get; set; }

        [MaxLength(25)]
        public string MediaType { get; set; }

        [MaxLength(300)]
        public string Image { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public Dictionary<string,string> FetchMetadata()
        {
            var metadata = new Dictionary<string,string>();

            metadata.Add("Title", Title);
            metadata.Add("MediaType", MediaType ?? "");
            metadata.Add("ImageURL", Image ?? "");
            metadata.Add("Description", Description ?? "");

            return metadata;
        }
    }
}
