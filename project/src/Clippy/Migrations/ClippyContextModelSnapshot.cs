﻿// <auto-generated />
using System;
using Clippy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clippy.Migrations
{
    [DbContext(typeof(ClippyContext))]
    partial class ClippyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Clippy.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Metadata")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Location")
                        .IsUnique();

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://www.nationalgeographic.com",
                            Metadata = "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/natgeo.jpg\",\"Description\":\"Explore the world\\u0027s beauty.\"}"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://www.nps.gov/yell/index.htm",
                            Metadata = "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/yellowstone.jpg\",\"Description\":\"Escape to a winter wonderland.\"}"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://www.foodnetwork.com",
                            Metadata = "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/foodnetwork.jpg\",\"Description\":\"Entice your taste buds.\"}"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://www.loveandlemons.com",
                            Metadata = "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/lovelemons.jpg\",\"Description\":\"Detoxify yourself each day.\"}"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://appalachiantrail.org",
                            Metadata = "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/appalachiantrail.jpg\",\"Description\":\"Escape the city lights.\"}"
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2021, 3, 4, 17, 22, 48, 75, DateTimeKind.Utc).AddTicks(6970),
                            Location = "https://www.spacex.com",
                            Metadata = "{\"Title\":\"SpaceX\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/spacex.jpg\",\"Description\":\"Experience space travel.\"}"
                        });
                });

            modelBuilder.Entity("Clippy.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
