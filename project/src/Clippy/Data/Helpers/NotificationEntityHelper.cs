using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers
{
    public static class NotificationEntityHelper
    {
        public static void AddNotificationEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Bookmark>()
                .HasIndex(b => b.UserId);
        }
    }
}
