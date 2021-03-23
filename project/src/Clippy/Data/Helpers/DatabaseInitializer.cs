using System;
using System.Collections.Generic;
using System.Linq;
using Clippy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clippy.Data.Helpers {
    public static class DatabaseInitializer
    {
        public static void AddSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(GetSeedingResources());
            modelBuilder.Entity<Role>()
                .HasData(GetSeedingRoles());
            modelBuilder.Entity<User>()
                .HasData(GetSeedingUsers());
            modelBuilder.Entity<Tag>()
                .HasData(GetSeedingTags());
            modelBuilder.Entity<Bookmark>()
                .HasData(GetSeedingBookmarks());
        }

        public static List<Resource> GetSeedingResources()
        {
            var r1 = new Resource
            {
                Id = 1,
                Location = "https://www.nationalgeographic.com",
                Metadata = new Dictionary<string,string>
                {
                    { "Title", "National Geographic" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "natgeo.jpg" },
                    { "Description", "Explore the world's beauty." }
                },
                CreateDate = new DateTime(2021, 3, 2, 14, 8, 6, DateTimeKind.Utc)
            };

            var r2  = new Resource
            {
                Id = 2,
                Location = "https://www.nps.gov/yell/index.htm",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Yellowstone National Park" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "yellowstone.jpg" },
                    { "Description", "Escape to a winter wonderland." }
                },
                CreateDate = new DateTime(2021, 3, 2, 18, 21, 8, DateTimeKind.Utc)
            };

            var r3  = new Resource
            {
                Id = 3,
                Location = "https://www.foodnetwork.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Food Network" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "foodnetwork.jpg" },
                    { "Description", "Entice your taste buds." }
                },
                CreateDate = new DateTime(2021, 3, 3, 17, 38, 42, DateTimeKind.Utc)
            };

            var r4  = new Resource
            {
                Id = 4,
                Location = "https://www.loveandlemons.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Love and Lemons" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "lovelemons.jpg" },
                    { "Description", "Detoxify yourself each day." }
                },
                CreateDate = new DateTime(2021, 3, 3, 23, 59, 0, DateTimeKind.Utc)
            };

            var r5  = new Resource
            {
                Id = 5,
                Location = "https://appalachiantrail.org",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "Appalachian Trail Conservancy" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "appalachiantrail.jpg" },
                    { "Description", "Escape the city lights." }
                },
                CreateDate = new DateTime(2021, 3, 4, 5, 12, 58, DateTimeKind.Utc)
            };

            var r6  = new Resource
            {
                Id = 6,
                Location = "https://www.spacex.com",
                Metadata = new Dictionary<string, string>
                {
                    { "Title", "SpaceX" },
                    { "MediaType", "text/html" },
                    { "ImageURL", "spacex.jpg" },
                    { "Description", "Experience space travel." }
                },
                CreateDate = new DateTime(2021, 3, 10, 9, 45, 32, DateTimeKind.Utc)
            };

            return new List<Resource>(new[] {r1, r2, r3, r4, r5, r6});
        }

        public static List<Role> GetSeedingRoles()
        {
            var r1 = new Role
            {
                Id = 1,
                Name = "Admin"
            };

            return new List<Role> (new[] {r1});
        }

        public static List<User> GetSeedingUsers()
        {
            var u1 = new User
            {
                Id = 1,
                Username = "Clippy5",
                Name = "Clippy5 Team",
                CreateDate = new DateTime(2021, 3, 1, 20, 32, 2, DateTimeKind.Utc),
                AvatarUrl = "/images/resources/rando.jpg",
                Bio = "Our moon is so useless and pathetic compared to all of the cool moons out there in the solar system. While so much other moons have all these cool features, all our Moon did was hit us, and then get a free ride orbiting us for a few billion years."
            };

            return new List<User> (new[] {u1});
        }

        public static List<Tag> GetSeedingTags()
        {
            var tags = new List<Tag>();

            var resources = GetSeedingResources();

            for(int i = 1; i < resources.Count; i++)
            {
                tags.Add(new Tag
                {
                    Id = i,
                    BookmarkId = i,
                    TagName = "favorite"
                });
            }

            return tags;
        }

        public static List<Bookmark> GetSeedingBookmarks()
        {
            var resources = GetSeedingResources();
            var user = GetSeedingUsers().First(u => u.Id == 1);

            var bookmarks = new List<Bookmark>();

            for(int i = 1; i < resources.Count; i++)
            {
                bookmarks.Add(new Bookmark
                {
                    Id = i,
                    ResourceId = resources[i].Id,
                    UserId = user.Id,
                    CreateDate = resources[i].CreateDate
                });
            }

            return bookmarks;
        }
    }
}
