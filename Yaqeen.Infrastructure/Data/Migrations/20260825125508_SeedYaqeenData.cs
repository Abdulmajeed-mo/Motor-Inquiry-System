using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yaqeen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedYaqeenData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "NationalId", "DateOfBirth", "FullName", "Gender", "Nationality" },
                values: new object[,]
                {
                    { "1028339274", new DateOnly(1990, 11, 15), "Alhasan Mustafa Alharbi", "Male", "Saudi" },
                    { "1234567890", new DateOnly(2003, 3, 3), "Abdulmajeed Mohammed Alhasani", "Male", "Saudi" },
                    { "1920009789", new DateOnly(2005, 2, 28), "Hamad Ahmed Al Sabah", "Male", "Saudi" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "SequenceNumber", "ChassisNumber", "Color", "Make", "Model", "ModelYear", "OwnerNationalId", "PlateLetters", "PlateNumber" },
                values: new object[,]
                {
                    { 1, "XYZ1234567890", "Black", "Toyota", "Crown Sedan", 2023, "1234567890", "MJD", "1303" },
                    { 2, "XYZ0987654321", "Blue", "Haval", "V7", 2019, "1028339274", "DEF", "5678" },
                    { 3, "XYZ5678901234", "Black", "Ford", "Mustang", 2020, "1920009789", "AAI", "9012" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "NationalId",
                keyValue: "1028339274");

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "NationalId",
                keyValue: "1234567890");

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "NationalId",
                keyValue: "1920009789");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "SequenceNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "SequenceNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "SequenceNumber",
                keyValue: 3);
        }
    }
}
