using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motor.Inquiry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleInquiryCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleInquiryCaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CacheKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PlateLetters = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerNationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CachedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInquiryCaches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInquiryCaches_CacheKey",
                table: "VehicleInquiryCaches",
                column: "CacheKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleInquiryCaches");
        }
    }
}
