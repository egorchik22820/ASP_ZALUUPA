using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ZALUUPA.Migrations
{
    /// <inheritdoc />
    public partial class adminHashCorrect1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6fc75900-94be-4fbc-9564-99e545ea978a", "07e61fca-0db1-4410-84c3-62afa497eeeb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc75900-94be-4fbc-9564-99e545ea978a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07e61fca-0db1-4410-84c3-62afa497eeeb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93ed7099-dedb-47af-8534-a4d4d1e1c31d", 0, "473d23aa-9d49-459e-b36d-9fe5c4e2c164", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAENs7qKiYXjREK7AnVcvOPIaQH13eZB3QOOH50vuVfztXdvKu72hEBbgLGW3/a9ZuLw==", null, true, "7233769f-2d13-4a91-8bad-72abe3aa2b1e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", "93ed7099-dedb-47af-8534-a4d4d1e1c31d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", "93ed7099-dedb-47af-8534-a4d4d1e1c31d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8bbcd93-b117-411b-b2dc-443e8dfeaa05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93ed7099-dedb-47af-8534-a4d4d1e1c31d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fc75900-94be-4fbc-9564-99e545ea978a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "07e61fca-0db1-4410-84c3-62afa497eeeb", 0, "08fe8469-0207-46aa-9ff2-a6ada1947258", "admin@admin.com", true, false, null, "admin@admin.com", "ADMIN", "AQAAAAIAAYagAAAAED8DjiWgXfET9/FUfbD2xl3bzI3mXTe0En1lc1OaidAoHadf1rRaGKIDyRvSdvxnGw==", null, true, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6fc75900-94be-4fbc-9564-99e545ea978a", "07e61fca-0db1-4410-84c3-62afa497eeeb" });
        }
    }
}
