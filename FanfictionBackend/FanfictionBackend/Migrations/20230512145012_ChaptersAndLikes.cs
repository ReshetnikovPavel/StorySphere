using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanfictionBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChaptersAndLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Fanfics");

            migrationBuilder.RenameColumn(
                name: "PostedOn",
                table: "Fanfics",
                newName: "Updated");

            migrationBuilder.AddColumn<int>(
                name: "PasswordId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PasswordId1",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Fanfics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    FanficId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.FanficId);
                    table.ForeignKey(
                        name: "FK_Chapters_Fanfics_FanficId",
                        column: x => x.FanficId,
                        principalTable: "Fanfics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FanficId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.FanficId });
                    table.ForeignKey(
                        name: "FK_Likes_Fanfics_FanficId",
                        column: x => x.FanficId,
                        principalTable: "Fanfics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Password",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordId",
                table: "Users",
                column: "PasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordId1",
                table: "Users",
                column: "PasswordId1");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FanficId",
                table: "Likes",
                column: "FanficId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Password_PasswordId",
                table: "Users",
                column: "PasswordId",
                principalTable: "Password",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Password_PasswordId1",
                table: "Users",
                column: "PasswordId1",
                principalTable: "Password",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Password_PasswordId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Password_PasswordId1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Password");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Fanfics");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Fanfics",
                newName: "PostedOn");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Fanfics",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
