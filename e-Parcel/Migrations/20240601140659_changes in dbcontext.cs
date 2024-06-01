using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_Parcel.Migrations
{
    /// <inheritdoc />
    public partial class changesindbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "44ed6d30-c79b-477f-ba0a-56ec4172033d", null, "User", "USER" },
                    { "da4f9378-01aa-4341-b620-3099feb414d3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ed6d30-c79b-477f-ba0a-56ec4172033d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da4f9378-01aa-4341-b620-3099feb414d3");

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
    }
}
