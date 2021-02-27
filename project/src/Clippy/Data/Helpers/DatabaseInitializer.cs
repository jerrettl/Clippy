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
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/natgeo.jpg" },
                    { "Description", "Explore the world's beauty." }
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
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/yellowstone.jpg" },
                    { "Description", "Escape to a winter wonderland." }
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
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/foodnetwork.jpg" },
                    { "Description", "Entice your taste buds." }
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
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/lovelemons.jpg" },
                    { "Description", "Detoxify yourself each day." }
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
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/appalachiantrail.jpg" },
                    { "Description", "Escape the city lights." }
                },
                CreateDate = now
            };

            var r6  = new Resource
            {
                Id = 6,
                Location = "https://www.spacex.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "SpaceX" },
                    { "MediaType", "text/html" },
                    { "Image", "https://api.clippy.fun/images/resources/spacex.jpg" },
                    { "Description", "Experience space travel." }
                },
                CreateDate = now
            };

            return new List<Resource>(new[] {r1, r2, r3, r4, r5, r6});
        }
    }
}
