using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers
{
    public static class BookmarkEntityHelper
    {
        public static void AddBookmarkEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Bookmark>()
                .HasIndex(b => b.ResourceId);

            modelBuilder.Entity<Bookmark>()
                .HasIndex(b => b.UserId);
        }
    }
}
