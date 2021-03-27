using System.Collections.Generic;

namespace Clippy.Models.Admin
{
    public class ImportResourceModel
    {
        public string Location { get; set; }

        public Dictionary<string,string> Metadata { get; set; }
    }
}
