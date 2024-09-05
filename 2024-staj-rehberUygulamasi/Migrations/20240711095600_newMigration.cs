using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_staj_rehberUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Kisiler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Kisiler",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
