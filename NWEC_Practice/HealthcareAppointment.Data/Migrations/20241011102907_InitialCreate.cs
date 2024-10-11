using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthcareAppointment.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name", "Password", "Role", "Specialization" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "John Doe", "password", "Patient", null },
                    { 2, new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe@gmail.com", "Jane Doe", "password", "Patient", null },
                    { 3, new DateTime(1975, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drsmith@gmail.com", "Dr. Smith", "password", "Doctor", "Cardiology" },
                    { 4, new DateTime(1980, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drbrown@gmail.com", "Dr. Brown", "password", "Doctor", "Neurology" },
                    { 5, new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dradams@gmail.com", "Dr. Adams", "password", "Doctor", "Pediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Scheduled" },
                    { 2, new DateTime(2024, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "Scheduled" },
                    { 3, new DateTime(2024, 10, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "Completed" },
                    { 4, new DateTime(2024, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "Scheduled" },
                    { 5, new DateTime(2024, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
