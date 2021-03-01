using System.Collections.Generic;

namespace Clippy.Helpers
{
    public static class MetadataHelper
    {
        public static void MergeMetadata(this Dictionary<string,string> d1, Dictionary<string,string> d2) {
            foreach(var key in d2.Keys)
            {
                // Replace
                if (d1.ContainsKey(key) && !string.IsNullOrWhiteSpace(d2[key]))
                {
                    d1[key] = d2[key];
                    continue;
                }

                // Delete
                if (d1.ContainsKey(key) && string.IsNullOrWhiteSpace(d2[key]))
                {
                    d1.Remove(key);
                    continue;
                }

                // Add
                if (!d1.ContainsKey(key) && !string.IsNullOrWhiteSpace(d2[key]))
                {
                    d1.Add(key, d2[key]);
                }
            }
        }
    }
}
