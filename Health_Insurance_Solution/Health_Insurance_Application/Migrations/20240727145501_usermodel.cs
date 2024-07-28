using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class usermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Users",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(533), new DateTime(2025, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(534), new DateTime(2025, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(529), new DateTime(2025, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(536), new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(590), new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(593), new DateTime(2025, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "Address", "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(370), new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(379), new byte[] { 235, 14, 55, 207, 96, 113, 141, 213, 75, 54, 243, 14, 91, 220, 74, 250, 56, 220, 78, 140, 64, 71, 151, 25, 139, 11, 103, 7, 200, 198, 172, 34, 123, 51, 225, 104, 237, 96, 16, 9, 151, 5, 156, 162, 142, 38, 254, 249, 44, 239, 96, 147, 215, 45, 203, 2, 191, 245, 240, 107, 78, 97, 174, 91 }, new byte[] { 238, 127, 249, 67, 141, 129, 245, 84, 44, 56, 65, 128, 156, 166, 253, 32, 96, 99, 211, 38, 253, 139, 19, 49, 237, 33, 178, 234, 152, 83, 230, 130, 235, 46, 80, 150, 152, 221, 153, 94, 65, 196, 173, 41, 58, 197, 89, 25, 118, 206, 111, 180, 129, 146, 241, 10, 133, 152, 53, 215, 130, 33, 6, 171, 7, 112, 180, 4, 252, 19, 153, 135, 222, 11, 151, 235, 207, 157, 85, 239, 35, 230, 108, 135, 30, 155, 236, 29, 184, 56, 228, 79, 148, 143, 112, 173, 189, 119, 158, 209, 114, 48, 169, 59, 10, 189, 217, 194, 54, 163, 46, 156, 75, 39, 117, 192, 98, 5, 233, 223, 251, 170, 37, 90, 139, 27, 229, 45 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "Address", "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(390), new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(390), new byte[] { 235, 14, 55, 207, 96, 113, 141, 213, 75, 54, 243, 14, 91, 220, 74, 250, 56, 220, 78, 140, 64, 71, 151, 25, 139, 11, 103, 7, 200, 198, 172, 34, 123, 51, 225, 104, 237, 96, 16, 9, 151, 5, 156, 162, 142, 38, 254, 249, 44, 239, 96, 147, 215, 45, 203, 2, 191, 245, 240, 107, 78, 97, 174, 91 }, new byte[] { 238, 127, 249, 67, 141, 129, 245, 84, 44, 56, 65, 128, 156, 166, 253, 32, 96, 99, 211, 38, 253, 139, 19, 49, 237, 33, 178, 234, 152, 83, 230, 130, 235, 46, 80, 150, 152, 221, 153, 94, 65, 196, 173, 41, 58, 197, 89, 25, 118, 206, 111, 180, 129, 146, 241, 10, 133, 152, 53, 215, 130, 33, 6, 171, 7, 112, 180, 4, 252, 19, 153, 135, 222, 11, 151, 235, 207, 157, 85, 239, 35, 230, 108, 135, 30, 155, 236, 29, 184, 56, 228, 79, 148, 143, 112, 173, 189, 119, 158, 209, 114, 48, 169, 59, 10, 189, 217, 194, 54, 163, 46, 156, 75, 39, 117, 192, 98, 5, 233, 223, 251, 170, 37, 90, 139, 27, 229, 45 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "Address", "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(399), new DateTime(2024, 7, 27, 20, 25, 0, 835, DateTimeKind.Local).AddTicks(399), new byte[] { 235, 14, 55, 207, 96, 113, 141, 213, 75, 54, 243, 14, 91, 220, 74, 250, 56, 220, 78, 140, 64, 71, 151, 25, 139, 11, 103, 7, 200, 198, 172, 34, 123, 51, 225, 104, 237, 96, 16, 9, 151, 5, 156, 162, 142, 38, 254, 249, 44, 239, 96, 147, 215, 45, 203, 2, 191, 245, 240, 107, 78, 97, 174, 91 }, new byte[] { 238, 127, 249, 67, 141, 129, 245, 84, 44, 56, 65, 128, 156, 166, 253, 32, 96, 99, 211, 38, 253, 139, 19, 49, 237, 33, 178, 234, 152, 83, 230, 130, 235, 46, 80, 150, 152, 221, 153, 94, 65, 196, 173, 41, 58, 197, 89, 25, 118, 206, 111, 180, 129, 146, 241, 10, 133, 152, 53, 215, 130, 33, 6, 171, 7, 112, 180, 4, 252, 19, 153, 135, 222, 11, 151, 235, 207, 157, 85, 239, 35, 230, 108, 135, 30, 155, 236, 29, 184, 56, 228, 79, 148, 143, 112, 173, 189, 119, 158, 209, 114, 48, 169, 59, 10, 189, 217, 194, 54, 163, 46, 156, 75, 39, 117, 192, 98, 5, 233, 223, 251, 170, 37, 90, 139, 27, 229, 45 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2545), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2545), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2540), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2548), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2539) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2698), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2697) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2700), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "City", "CreatedAt", "LastUpdated", "Password", "Salt", "State", "Street" },
                values: new object[] { "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2208), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2227), new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "Test Lorem , blaaa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "City", "CreatedAt", "LastUpdated", "Password", "Salt", "State", "Street" },
                values: new object[] { "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2247), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2248), new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "Test lorem , fam" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "City", "CreatedAt", "LastUpdated", "Password", "Salt", "State", "Street" },
                values: new object[] { "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2323), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2323), new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "789 Oak St" });
        }
    }
}
