using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore_Task1.Migrations
{
    /// <inheritdoc />
    public partial class updateCustomerProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "CustomerProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "CustomerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
