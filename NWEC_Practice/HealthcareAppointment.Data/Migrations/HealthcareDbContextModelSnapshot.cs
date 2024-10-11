﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthcareAppointment.Data.Migrations
{
    [DbContext(typeof(HealthcareDbContext))]
    partial class HealthcareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            PatientId = 1,
                            Status = "Scheduled"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            PatientId = 2,
                            Status = "Scheduled"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 10, 13, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4,
                            PatientId = 1,
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 5,
                            PatientId = 2,
                            Status = "Scheduled"
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 5,
                            PatientId = 1,
                            Status = "Cancelled"
                        });
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@gmail.com",
                            Name = "John Doe",
                            Password = "password",
                            Role = "Patient"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "janedoe@gmail.com",
                            Name = "Jane Doe",
                            Password = "password",
                            Role = "Patient"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1975, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "drsmith@gmail.com",
                            Name = "Dr. Smith",
                            Password = "password",
                            Role = "Doctor",
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1980, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "drbrown@gmail.com",
                            Name = "Dr. Brown",
                            Password = "password",
                            Role = "Doctor",
                            Specialization = "Neurology"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dradams@gmail.com",
                            Name = "Dr. Adams",
                            Password = "password",
                            Role = "Doctor",
                            Specialization = "Pediatrics"
                        });
                });

            modelBuilder.Entity("Appointment", b =>
                {
                    b.HasOne("User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
