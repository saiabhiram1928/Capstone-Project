using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class updatedpolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Schemes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Claims",
                keyColumn: "ClaimId",
                keyValue: 1,
                column: "ClaimedDate",
                value: new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5925), new DateTime(2025, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5925), new DateTime(2025, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5921), new DateTime(2025, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5927), new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5921) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6059), new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6058) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6061), new DateTime(2025, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5942) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                columns: new[] { "IsActive", "SchemeLastUpdatedAt" },
                values: new object[] { true, new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5952) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5725), new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5741), new byte[] { 234, 234, 174, 201, 190, 120, 206, 209, 81, 129, 185, 174, 40, 20, 167, 97, 8, 183, 72, 236, 253, 155, 77, 30, 241, 206, 187, 87, 101, 116, 76, 42, 71, 194, 166, 137, 184, 44, 249, 212, 250, 133, 2, 225, 161, 164, 202, 247, 213, 11, 250, 187, 168, 167, 25, 1, 25, 109, 241, 12, 144, 139, 177, 204 }, new byte[] { 185, 142, 169, 216, 226, 11, 84, 0, 49, 227, 142, 246, 51, 17, 40, 205, 66, 41, 59, 172, 116, 43, 188, 223, 57, 174, 124, 144, 84, 82, 145, 85, 99, 18, 194, 137, 55, 245, 57, 46, 114, 177, 130, 7, 178, 105, 68, 137, 135, 218, 211, 2, 178, 83, 30, 227, 254, 11, 191, 238, 132, 41, 105, 26, 86, 60, 237, 90, 172, 196, 11, 82, 75, 171, 225, 190, 143, 210, 168, 62, 103, 177, 37, 73, 128, 185, 167, 52, 45, 98, 179, 25, 84, 79, 124, 50, 246, 21, 165, 84, 146, 161, 38, 123, 55, 210, 121, 160, 124, 40, 78, 207, 176, 123, 66, 175, 29, 80, 80, 86, 200, 26, 251, 33, 63, 24, 64, 120 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5754), new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5755), new byte[] { 234, 234, 174, 201, 190, 120, 206, 209, 81, 129, 185, 174, 40, 20, 167, 97, 8, 183, 72, 236, 253, 155, 77, 30, 241, 206, 187, 87, 101, 116, 76, 42, 71, 194, 166, 137, 184, 44, 249, 212, 250, 133, 2, 225, 161, 164, 202, 247, 213, 11, 250, 187, 168, 167, 25, 1, 25, 109, 241, 12, 144, 139, 177, 204 }, new byte[] { 185, 142, 169, 216, 226, 11, 84, 0, 49, 227, 142, 246, 51, 17, 40, 205, 66, 41, 59, 172, 116, 43, 188, 223, 57, 174, 124, 144, 84, 82, 145, 85, 99, 18, 194, 137, 55, 245, 57, 46, 114, 177, 130, 7, 178, 105, 68, 137, 135, 218, 211, 2, 178, 83, 30, 227, 254, 11, 191, 238, 132, 41, 105, 26, 86, 60, 237, 90, 172, 196, 11, 82, 75, 171, 225, 190, 143, 210, 168, 62, 103, 177, 37, 73, 128, 185, 167, 52, 45, 98, 179, 25, 84, 79, 124, 50, 246, 21, 165, 84, 146, 161, 38, 123, 55, 210, 121, 160, 124, 40, 78, 207, 176, 123, 66, 175, 29, 80, 80, 86, 200, 26, 251, 33, 63, 24, 64, 120 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5765), new DateTime(2024, 8, 3, 11, 10, 21, 566, DateTimeKind.Local).AddTicks(5765), new byte[] { 234, 234, 174, 201, 190, 120, 206, 209, 81, 129, 185, 174, 40, 20, 167, 97, 8, 183, 72, 236, 253, 155, 77, 30, 241, 206, 187, 87, 101, 116, 76, 42, 71, 194, 166, 137, 184, 44, 249, 212, 250, 133, 2, 225, 161, 164, 202, 247, 213, 11, 250, 187, 168, 167, 25, 1, 25, 109, 241, 12, 144, 139, 177, 204 }, new byte[] { 185, 142, 169, 216, 226, 11, 84, 0, 49, 227, 142, 246, 51, 17, 40, 205, 66, 41, 59, 172, 116, 43, 188, 223, 57, 174, 124, 144, 84, 82, 145, 85, 99, 18, 194, 137, 55, 245, 57, 46, 114, 177, 130, 7, 178, 105, 68, 137, 135, 218, 211, 2, 178, 83, 30, 227, 254, 11, 191, 238, 132, 41, 105, 26, 86, 60, 237, 90, 172, 196, 11, 82, 75, 171, 225, 190, 143, 210, 168, 62, 103, 177, 37, 73, 128, 185, 167, 52, 45, 98, 179, 25, 84, 79, 124, 50, 246, 21, 165, 84, 146, 161, 38, 123, 55, 210, 121, 160, 124, 40, 78, 207, 176, 123, 66, 175, 29, 80, 80, 86, 200, 26, 251, 33, 63, 24, 64, 120 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Schemes");

            migrationBuilder.UpdateData(
                table: "Claims",
                keyColumn: "ClaimId",
                keyValue: 1,
                column: "ClaimedDate",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2285), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2287), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2280), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2291), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2555), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2558), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1879), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1894), new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1927), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1927), new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1953), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1954), new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 } });
        }
    }
}
