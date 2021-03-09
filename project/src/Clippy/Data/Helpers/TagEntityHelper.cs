using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers {
    public static class TagEntityHelper
    {
        public static void AddTagEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.BookmarkId);
        }
    }
}
