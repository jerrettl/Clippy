using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers {
    public static class UserEntityHelper
    {
        public static void AddUserEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
