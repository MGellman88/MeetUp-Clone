﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBelt.Data;

namespace TheBelt.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181115221829_SixthMigration")]
    partial class SixthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TheBelt.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Event");

                    b.Property<string>("Location");

                    b.Property<int>("UserId");

                    b.HasKey("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TheBelt.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AcitivityId");

                    b.Property<int?>("ActivityId");

                    b.Property<int>("UserId");

                    b.HasKey("ParticipantId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("TheBelt.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.HasIndex("ActivityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheBelt.Models.Activity", b =>
                {
                    b.HasOne("TheBelt.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheBelt.Models.Participant", b =>
                {
                    b.HasOne("TheBelt.Models.Activity", "Activity")
                        .WithMany("Participants")
                        .HasForeignKey("ActivityId");

                    b.HasOne("TheBelt.Models.User", "Attending")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheBelt.Models.User", b =>
                {
                    b.HasOne("TheBelt.Models.Activity")
                        .WithMany("Users")
                        .HasForeignKey("ActivityId");
                });
#pragma warning restore 612, 618
        }
    }
}
