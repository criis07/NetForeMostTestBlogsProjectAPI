using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetForeMostTestBlogsProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "FirstName", "LastName", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 9, 26, 1, 7, 7, 814, DateTimeKind.Utc).AddTicks(8953), "Brandon", "Smith", null, null },
                    { 2, true, 1, new DateTime(2024, 9, 26, 1, 7, 7, 814, DateTimeKind.Utc).AddTicks(8955), "Allison", "Brown", null, null },
                    { 3, false, 1, new DateTime(2024, 9, 26, 1, 7, 7, 814, DateTimeKind.Utc).AddTicks(8956), "Patricia", "McDonald", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
