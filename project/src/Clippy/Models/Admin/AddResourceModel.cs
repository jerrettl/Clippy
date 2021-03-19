using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clippy.Models.Admin
{
    public class AddResourceModel
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
            if (!string.IsNullOrWhiteSpace(MediaType))
                metadata.Add("MediaType", MediaType);
            if (!string.IsNullOrWhiteSpace(Image))
                metadata.Add("ImageURL", Image);
            if (!string.IsNullOrWhiteSpace(Description))
                metadata.Add("Description", Description);

            return metadata;
        }
    }
}
