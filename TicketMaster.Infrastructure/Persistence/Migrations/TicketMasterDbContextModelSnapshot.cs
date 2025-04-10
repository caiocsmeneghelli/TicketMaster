﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketMaster.Infrastructure.Persistence;

#nullable disable

namespace TicketMaster.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(TicketMasterDbContext))]
    partial class TicketMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TicketMaster.Domain.Entities.Auditorium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditoriumType")
                        .HasColumnType("int");

                    b.Property<int>("IdTheater")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTheater");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Director")
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.MovieSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AudioAttribute")
                        .HasColumnType("int");

                    b.Property<int>("IdAuditorium")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.Property<int>("ImageAttribute")
                        .HasColumnType("int");

                    b.Property<int>("ReservedSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("IdAuditorium");

                    b.HasIndex("IdMovie");

                    b.ToTable("MovieSessions");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.Theater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.Auditorium", b =>
                {
                    b.HasOne("TicketMaster.Domain.Entities.Theater", "Theater")
                        .WithMany("Auditoriums")
                        .HasForeignKey("IdTheater")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.MovieSession", b =>
                {
                    b.HasOne("TicketMaster.Domain.Entities.Auditorium", "Auditorium")
                        .WithMany()
                        .HasForeignKey("IdAuditorium")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketMaster.Domain.Entities.Movie", "Movie")
                        .WithMany("MovieSessions")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.Movie", b =>
                {
                    b.Navigation("MovieSessions");
                });

            modelBuilder.Entity("TicketMaster.Domain.Entities.Theater", b =>
                {
                    b.Navigation("Auditoriums");
                });
#pragma warning restore 612, 618
        }
    }
}
