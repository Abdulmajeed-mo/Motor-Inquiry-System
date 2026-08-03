using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motor.Inquiry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInquiryHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.CreateTable(
                name: "InquiryHistories",
                columns: table => new
                {
                    InquiryHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquiryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateLetters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryHistories", x => x.InquiryHistoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InquiryHistories");

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    InquiryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    PlateLetters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.InquiryId);
                });
        }
    }
}
