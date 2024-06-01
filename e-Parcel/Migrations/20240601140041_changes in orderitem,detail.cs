using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_Parcel.Migrations
{
    /// <inheritdoc />
    public partial class changesinorderitemdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8814475b-48a0-413d-bc56-501f726b58e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c874e8b2-7729-4a5a-a414-580da5e3cc65");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04d9d42c-faed-4a59-a64f-6b347259bfeb", null, "Admin", "ADMIN" },
                    { "1b161160-ad64-4def-bd3d-61f9e72c50c8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d9d42c-faed-4a59-a64f-6b347259bfeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b161160-ad64-4def-bd3d-61f9e72c50c8");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8814475b-48a0-413d-bc56-501f726b58e8", null, "User", "USER" },
                    { "c874e8b2-7729-4a5a-a414-580da5e3cc65", null, "Admin", "ADMIN" }
                });
        }
    }
}
