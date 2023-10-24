﻿// <auto-generated />
using System;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PollApi.Migrations
{
    [DbContext(typeof(PollDbContext))]
    [Migration("20231021190807_AddedForeignKeyFromVotesToEvents")]
    partial class AddedForeignKeyFromVotesToEvents
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.PollEvent", b =>
                {
                    b.Property<int>("PollEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PollEventId"));

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 21, 22, 8, 7, 541, DateTimeKind.Local).AddTicks(6625));

                    b.Property<Guid>("EventGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NewId()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PollEventId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Models.PollLicense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PollLicense");
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.Property<int>("PollOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PollOptionId"));

                    b.Property<int>("PollEventId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PollOptionId");

                    b.HasIndex("PollEventId");

                    b.ToTable("EventOptions");
                });

            modelBuilder.Entity("Domain.Models.PollVote", b =>
                {
                    b.Property<int>("PollVoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PollVoteId"));

                    b.Property<string>("CustomValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PollEventId")
                        .HasColumnType("int");

                    b.Property<int>("PollOptionId")
                        .HasColumnType("int");

                    b.HasKey("PollVoteId");

                    b.HasIndex("PollOptionId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivationHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.PollEvent", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.PollLicense", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithOne("License")
                        .HasForeignKey("Domain.Models.PollLicense", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.HasOne("Domain.Models.PollEvent", null)
                        .WithMany("Options")
                        .HasForeignKey("PollEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.PollVote", b =>
                {
                    b.HasOne("Domain.Models.PollOption", null)
                        .WithMany("Votes")
                        .HasForeignKey("PollOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.PollEvent", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("License")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}