using Clippy.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;

namespace Clippy.Data.Helpers {
    public static class ResourceEntityHelper
    {
        public static void AddResourceEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.Location)
                .IsUnique();

            modelBuilder.Entity<Resource>()
                .Property(r => r.Metadata)
                .HasColumnType("varchar")
                .IsRequired()
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, null)
                );
        }
    }
}
