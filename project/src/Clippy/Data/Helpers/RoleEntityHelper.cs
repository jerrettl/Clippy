using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers {
    public static class RoleEntityHelper
    {
        public static void AddRoleEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}
