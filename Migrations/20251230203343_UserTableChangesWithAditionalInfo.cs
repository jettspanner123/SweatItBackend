using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweatItBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UserTableChangesWithAditionalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonCurrentDataId",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonFutureDataId",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    BodyType = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<int>(type: "integer", nullable: false),
                    DailyPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonCurrentDataId",
                table: "Users",
                column: "PersonCurrentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonFutureDataId",
                table: "Users",
                column: "PersonFutureDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonData_PersonCurrentDataId",
                table: "Users",
                column: "PersonCurrentDataId",
                principalTable: "PersonData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonData_PersonFutureDataId",
                table: "Users",
                column: "PersonFutureDataId",
                principalTable: "PersonData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonData_PersonCurrentDataId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonData_PersonFutureDataId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PersonData");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonCurrentDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonFutureDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonCurrentDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonFutureDataId",
                table: "Users");
        }
    }
}
