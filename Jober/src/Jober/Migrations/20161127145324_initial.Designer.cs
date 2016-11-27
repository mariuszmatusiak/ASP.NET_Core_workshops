using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Jober.Data;

namespace Jober.Migrations
{
    [DbContext(typeof(AppDB))]
    [Migration("20161127145324_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jober.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Jober.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Added");

                    b.Property<int>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("JobId");

                    b.HasIndex("CityId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Jober.Models.Job", b =>
                {
                    b.HasOne("Jober.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
