﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTicket.Data.Persistence;

#nullable disable

namespace MyTicket.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240824212813_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyTicket.Data.Models.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CinemaHalls");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaHallId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CinemaHallId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Showtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaHallId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CinemaHallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SeatId");

                    b.HasIndex("ShowtimeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Payment", b =>
                {
                    b.HasOne("MyTicket.Data.Models.Ticket", "Ticket")
                        .WithOne("Payment")
                        .HasForeignKey("MyTicket.Data.Models.Payment", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Review", b =>
                {
                    b.HasOne("MyTicket.Data.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyTicket.Data.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Seat", b =>
                {
                    b.HasOne("MyTicket.Data.Models.CinemaHall", "CinemaHall")
                        .WithMany("Seats")
                        .HasForeignKey("CinemaHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Showtime", b =>
                {
                    b.HasOne("MyTicket.Data.Models.CinemaHall", "CinemaHall")
                        .WithMany("Showtimes")
                        .HasForeignKey("CinemaHallId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyTicket.Data.Models.Movie", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Ticket", b =>
                {
                    b.HasOne("MyTicket.Data.Models.Customer", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyTicket.Data.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyTicket.Data.Models.Showtime", "Showtime")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Seat");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("MyTicket.Data.Models.CinemaHall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Customer", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Movie", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Showtime", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MyTicket.Data.Models.Ticket", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}