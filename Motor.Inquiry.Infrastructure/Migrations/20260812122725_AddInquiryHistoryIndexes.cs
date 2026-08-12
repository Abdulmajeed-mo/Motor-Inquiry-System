using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motor.Inquiry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInquiryHistoryIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "InquiryHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlateLetters",
                table: "InquiryHistories",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "InquiryHistories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryHistories_CreatedAt",
                table: "InquiryHistories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryHistories_NationalId",
                table: "InquiryHistories",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryHistories_PlateNumber_PlateLetters",
                table: "InquiryHistories",
                columns: new[] { "PlateNumber", "PlateLetters" });

            migrationBuilder.CreateIndex(
                name: "IX_InquiryHistories_SequenceNumber",
                table: "InquiryHistories",
                column: "SequenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InquiryHistories_CreatedAt",
                table: "InquiryHistories");

            migrationBuilder.DropIndex(
                name: "IX_InquiryHistories_NationalId",
                table: "InquiryHistories");

            migrationBuilder.DropIndex(
                name: "IX_InquiryHistories_PlateNumber_PlateLetters",
                table: "InquiryHistories");

            migrationBuilder.DropIndex(
                name: "IX_InquiryHistories_SequenceNumber",
                table: "InquiryHistories");

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "InquiryHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlateLetters",
                table: "InquiryHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "InquiryHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
