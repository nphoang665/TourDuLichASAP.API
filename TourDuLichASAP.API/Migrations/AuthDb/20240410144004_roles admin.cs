using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourDuLichASAP.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class rolesadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "294bb644-8b4e-4d5b-8bab-e5ed8b2d864e", "b83cf6dd-435c-48cd-8c16-06338e726032" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8db11b28-ce22-475f-8b1e-d23d2e100fcf", "b83cf6dd-435c-48cd-8c16-06338e726032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b2ba0b-c552-44f6-bf4d-cc46fa5731b5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf99dbea-d9fb-4ec0-a723-0ea552172c65", "AQAAAAIAAYagAAAAEHPrlz/Qv51JSx7muKrOsXVXC7PM9ZP7zadfxDjU4IkoHSx+5cpGmLOXKZbQl6Ed2g==", "00693723-5abe-4226-8c27-da35c857ff5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b83cf6dd-435c-48cd-8c16-06338e726032",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6ea04a9-7484-4ea2-a731-f9b9d3ed5bac", "AQAAAAIAAYagAAAAEC7h8zV3/XtWHjPtwI+02nVrKqAugtKrGZCjWyvc4Ka3asxkKm7WD5/e1FrdayHOeA==", "f4513a35-b318-4f7c-95bb-75e3dfc895fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf1cd73a-9d5e-4a19-8e77-28c13c57f39b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2394d2a9-0a41-4388-bb02-2d6631006925", "AQAAAAIAAYagAAAAEIf4ZEsY1XCJp+f0Obhdq4hXvGoY84vK8WjgYBcluIZNg0WTlabM9UbhDQmTH6wZsQ==", "a42f8534-1c25-4d36-91b8-e4a594be80ae" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "294bb644-8b4e-4d5b-8bab-e5ed8b2d864e", "b83cf6dd-435c-48cd-8c16-06338e726032" },
                    { "8db11b28-ce22-475f-8b1e-d23d2e100fcf", "b83cf6dd-435c-48cd-8c16-06338e726032" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b2ba0b-c552-44f6-bf4d-cc46fa5731b5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aaeb858-acef-479d-b09f-f53d7fd6785f", "AQAAAAIAAYagAAAAEALCx9M0PpANDDznXkOL4G3vTlImcIgypvE+PYHmoVjhDDw5124qm0PJP3T5b/QKDQ==", "e5ec0211-6144-449b-9736-4380aa6033ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b83cf6dd-435c-48cd-8c16-06338e726032",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "535baf9b-9375-44b4-b2ca-97797a507923", "AQAAAAIAAYagAAAAENglT8kIAozozLOyDDo8xLQ0Hb4z58GPWtoGdsXXbeqZjnUcE7nTQfzY1PboulNcVw==", "96a5002a-5b8c-4ee4-815f-36b07999c375" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf1cd73a-9d5e-4a19-8e77-28c13c57f39b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46c4d955-40ee-4f95-aea7-169539997fba", "AQAAAAIAAYagAAAAEOhVhK6rU5GpmKjAgmHOJV+Zfv2pJRiJm9nG3K6Kb9mFyFMnEkbvpCfGf7DXHNM4fQ==", "6d875b89-751d-4a9a-85cb-8487b618e2c4" });
        }
    }
}
