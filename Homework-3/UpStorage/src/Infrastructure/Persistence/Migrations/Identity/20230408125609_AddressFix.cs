using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddressFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "Addresses",
                type: "varchar(191)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(191)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "UserId1",
                keyValue: null,
                column: "UserId1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "Addresses",
                type: "varchar(191)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(191)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
