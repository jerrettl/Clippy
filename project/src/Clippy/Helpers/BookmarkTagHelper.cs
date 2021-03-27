using Clippy.Entities;
using System.Collections.Generic;
using System.Text;

namespace Clippy.Helpers
{
    public static class BookmarkTagHelper
    {
        // Converts tag list to string.
        public static string ListToString(IList<Tag> tags)
        {
            StringBuilder sb = new StringBuilder();
            
            int i = 0;
            foreach(Tag tag in tags) {
                if (i > 0 && i < tags.Count)
                    sb.Append(", ");
                sb.Append(tag.TagName);
                i++;
            }

            return sb.ToString();
        }

        // Converts a comma-separated string to a list of tags.
        public static IList<Tag> StringToList(string tags)
        {
            var output = new List<Tag>();

            // Quit early if tags are empty.
            if (string.IsNullOrWhiteSpace(tags))
            {
                return output;
            }

            string[] stringSplit = tags.Split(',');

            foreach (string tag in stringSplit) {
                if (string.IsNullOrWhiteSpace(tag))
                    continue;

                Tag newTag = new Tag { TagName = tag.Trim() };

                if (ContainsTag(output, newTag))
                    continue;

                output.Add(newTag);
            }

            return output;
        }

        private static bool ContainsTag(IList<Tag> tags, Tag query)
        {
            foreach (Tag tag in tags)
            {
                if (query.TagName.Equals(tag.TagName)) return true;
            }

            return false;
        }
    }
}
