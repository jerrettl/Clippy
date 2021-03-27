using System.Collections.Generic;

namespace Clippy.Models.Admin
{
    public class ExportResourceModel
    {
        public int Id  { get; set; }

        public string Location { get; set; }

        public Dictionary<string,string> Metadata { get; set; }
    }
}
