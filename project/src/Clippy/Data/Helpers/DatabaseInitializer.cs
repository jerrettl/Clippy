using System;
using System.Collections.Generic;
using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers {
    public static class DatabaseInitializer
    {
        public static void AddSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(GetSeedingResources());
        }

        public static List<Resource> GetSeedingResources() {
            var now = DateTime.UtcNow;

            var r1 = new Resource
            {
                Id = 1,
                Location = "https://www.nationalgeographic.com",
                Metadata = new Dictionary<string,string>
                {
                    { "Title", "National Geographic" },
                    { "MediaType", "text/html" }
                },
                CreateDate = now
            };

            var r2  = new Resource
            {
                Id = 2,
                Location = "https://www.nps.gov/yell/index.htm",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Yellowstone National Park" },
                    { "MediaType", "text/html" }
                },
                CreateDate = now
            };

            var r3  = new Resource
            {
                Id = 3,
                Location = "https://www.foodnetwork.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Food Network" },
                    { "MediaType", "text/html" }
                },
                CreateDate = now
            };

            var r4  = new Resource
            {
                Id = 4,
                Location = "https://www.loveandlemons.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Love and Lemons" },
                    { "MediaType", "text/html" }
                },
                CreateDate = now
            };

            var r5  = new Resource
            {
                Id = 5,
                Location = "https://appalachiantrail.org",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Appalachian Trail Conservancy" },
                    { "MediaType", "text/html" }
                },
                CreateDate = now
            };

            return new List<Resource>(new[] {r1, r2, r3, r4, r5});
        }
    }
}
