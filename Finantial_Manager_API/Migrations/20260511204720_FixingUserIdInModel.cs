using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finantial_Manager_API.Migrations
{
    /// <inheritdoc />
    public partial class FixingUserIdInModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("293c0022-db65-42f3-806e-416544ba4aea"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("537d5c4b-b4e2-48bc-a0da-a6773ee3afe2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67c30f41-1692-470f-8e95-8b860ebc941b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a58774f2-22e6-4dfb-948f-f7eaf4451f81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdddbc13-a9f9-4f73-b97d-280ef80ac14b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2872953-de74-4c7a-8115-1bd457468596"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1e84489-9df4-4d60-8cd6-ca2a8b2ae5f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff811118-507c-4b8e-b6b9-bbefff2d9a48"));

            migrationBuilder.RenameColumn(
                name: "Ind",
                table: "Users",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "Icon", "IsActive", "IsDefault", "Name", "ParentCategoryId", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e924aab-5b90-4342-b9e1-92172f995cd3"), "#8B5CF6", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(4001), null, "car", true, true, "Transport", null, 1, null, null },
                    { new Guid("39de397b-8f7d-406b-b21b-ce736cafb4e1"), "#EC4899", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(4021), null, "heart-pulse", true, true, "Health", null, 1, null, null },
                    { new Guid("3d195d65-6234-438b-8f3a-ea6179c3de2b"), "#F97316", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(3998), null, "utensils", true, true, "Food", null, 1, null, null },
                    { new Guid("4488a0d3-a34a-4669-aa39-6da8b273af36"), "#14B8A6", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(4024), null, "book-open", true, true, "Education", null, 1, null, null },
                    { new Guid("da7419ae-5a37-4023-8684-bbf7c132121e"), "#22C55E", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(772), null, "briefcase", true, true, "Salary", null, 0, null, null },
                    { new Guid("df1885e8-b393-4f26-a017-d8c91beed922"), "#F59E0B", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(4027), null, "gamepad-2", true, true, "Leisure", null, 1, null, null },
                    { new Guid("f768055e-0520-4515-ad3f-0ea2882b69b2"), "#EF4444", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(4018), null, "file-text", true, true, "Bills", null, 1, null, null },
                    { new Guid("fec0e21f-7b35-41f4-a0f8-8c0af6916591"), "#3B82F6", new DateTime(2026, 5, 11, 20, 47, 19, 341, DateTimeKind.Utc).AddTicks(3991), null, "laptop", true, true, "Freelance", null, 0, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e924aab-5b90-4342-b9e1-92172f995cd3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("39de397b-8f7d-406b-b21b-ce736cafb4e1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3d195d65-6234-438b-8f3a-ea6179c3de2b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4488a0d3-a34a-4669-aa39-6da8b273af36"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da7419ae-5a37-4023-8684-bbf7c132121e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df1885e8-b393-4f26-a017-d8c91beed922"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f768055e-0520-4515-ad3f-0ea2882b69b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fec0e21f-7b35-41f4-a0f8-8c0af6916591"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "Ind");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "Icon", "IsActive", "IsDefault", "Name", "ParentCategoryId", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("293c0022-db65-42f3-806e-416544ba4aea"), "#F59E0B", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9971), null, "gamepad-2", true, true, "Leisure", null, 1, null, null },
                    { new Guid("537d5c4b-b4e2-48bc-a0da-a6773ee3afe2"), "#3B82F6", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9944), null, "laptop", true, true, "Freelance", null, 0, null, null },
                    { new Guid("67c30f41-1692-470f-8e95-8b860ebc941b"), "#22C55E", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(6624), null, "briefcase", true, true, "Salary", null, 0, null, null },
                    { new Guid("a58774f2-22e6-4dfb-948f-f7eaf4451f81"), "#14B8A6", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9968), null, "book-open", true, true, "Education", null, 1, null, null },
                    { new Guid("bdddbc13-a9f9-4f73-b97d-280ef80ac14b"), "#EC4899", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9965), null, "heart-pulse", true, true, "Health", null, 1, null, null },
                    { new Guid("d2872953-de74-4c7a-8115-1bd457468596"), "#EF4444", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9956), null, "file-text", true, true, "Bills", null, 1, null, null },
                    { new Guid("f1e84489-9df4-4d60-8cd6-ca2a8b2ae5f0"), "#F97316", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9950), null, "utensils", true, true, "Food", null, 1, null, null },
                    { new Guid("ff811118-507c-4b8e-b6b9-bbefff2d9a48"), "#8B5CF6", new DateTime(2026, 5, 7, 20, 54, 10, 721, DateTimeKind.Utc).AddTicks(9954), null, "car", true, true, "Transport", null, 1, null, null }
                });
        }
    }
}
