using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2213), new DateTime(2025, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2213), new DateTime(2025, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2207), new DateTime(2025, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2216), new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2399), new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2402), new DateTime(2025, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "MobileNumber", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1932), new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1947), "9999999991", new byte[] { 50, 171, 202, 48, 240, 87, 137, 2, 219, 243, 202, 6, 110, 203, 191, 167, 160, 103, 78, 33, 100, 174, 20, 164, 39, 59, 3, 88, 126, 226, 45, 20, 110, 134, 32, 144, 183, 243, 97, 208, 195, 127, 126, 8, 215, 63, 0, 107, 87, 242, 43, 242, 140, 157, 190, 181, 184, 12, 228, 117, 19, 7, 44, 0 }, new byte[] { 226, 83, 198, 146, 107, 34, 240, 71, 15, 43, 52, 217, 221, 223, 1, 142, 12, 155, 204, 166, 224, 40, 106, 65, 43, 39, 1, 64, 23, 24, 59, 150, 184, 227, 217, 70, 136, 235, 137, 110, 56, 186, 83, 166, 179, 211, 127, 240, 240, 214, 87, 112, 163, 231, 247, 222, 165, 73, 232, 19, 65, 25, 128, 242, 0, 254, 50, 247, 90, 241, 71, 50, 43, 218, 81, 211, 84, 119, 69, 96, 74, 159, 233, 153, 180, 157, 72, 163, 181, 66, 25, 230, 223, 36, 249, 178, 168, 61, 169, 88, 67, 98, 57, 61, 7, 245, 99, 79, 6, 201, 242, 253, 130, 202, 104, 126, 196, 78, 193, 122, 21, 114, 204, 160, 140, 114, 221, 95 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1965), new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1965), new byte[] { 50, 171, 202, 48, 240, 87, 137, 2, 219, 243, 202, 6, 110, 203, 191, 167, 160, 103, 78, 33, 100, 174, 20, 164, 39, 59, 3, 88, 126, 226, 45, 20, 110, 134, 32, 144, 183, 243, 97, 208, 195, 127, 126, 8, 215, 63, 0, 107, 87, 242, 43, 242, 140, 157, 190, 181, 184, 12, 228, 117, 19, 7, 44, 0 }, new byte[] { 226, 83, 198, 146, 107, 34, 240, 71, 15, 43, 52, 217, 221, 223, 1, 142, 12, 155, 204, 166, 224, 40, 106, 65, 43, 39, 1, 64, 23, 24, 59, 150, 184, 227, 217, 70, 136, 235, 137, 110, 56, 186, 83, 166, 179, 211, 127, 240, 240, 214, 87, 112, 163, 231, 247, 222, 165, 73, 232, 19, 65, 25, 128, 242, 0, 254, 50, 247, 90, 241, 71, 50, 43, 218, 81, 211, 84, 119, 69, 96, 74, 159, 233, 153, 180, 157, 72, 163, 181, 66, 25, 230, 223, 36, 249, 178, 168, 61, 169, 88, 67, 98, 57, 61, 7, 245, 99, 79, 6, 201, 242, 253, 130, 202, 104, 126, 196, 78, 193, 122, 21, 114, 204, 160, 140, 114, 221, 95 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1983), new DateTime(2024, 7, 31, 10, 59, 32, 743, DateTimeKind.Local).AddTicks(1983), new byte[] { 50, 171, 202, 48, 240, 87, 137, 2, 219, 243, 202, 6, 110, 203, 191, 167, 160, 103, 78, 33, 100, 174, 20, 164, 39, 59, 3, 88, 126, 226, 45, 20, 110, 134, 32, 144, 183, 243, 97, 208, 195, 127, 126, 8, 215, 63, 0, 107, 87, 242, 43, 242, 140, 157, 190, 181, 184, 12, 228, 117, 19, 7, 44, 0 }, new byte[] { 226, 83, 198, 146, 107, 34, 240, 71, 15, 43, 52, 217, 221, 223, 1, 142, 12, 155, 204, 166, 224, 40, 106, 65, 43, 39, 1, 64, 23, 24, 59, 150, 184, 227, 217, 70, 136, 235, 137, 110, 56, 186, 83, 166, 179, 211, 127, 240, 240, 214, 87, 112, 163, 231, 247, 222, 165, 73, 232, 19, 65, 25, 128, 242, 0, 254, 50, 247, 90, 241, 71, 50, 43, 218, 81, 211, 84, 119, 69, 96, 74, 159, 233, 153, 180, 157, 72, 163, 181, 66, 25, 230, 223, 36, 249, 178, 168, 61, 169, 88, 67, 98, 57, 61, 7, 245, 99, 79, 6, 201, 242, 253, 130, 202, 104, 126, 196, 78, 193, 122, 21, 114, 204, 160, 140, 114, 221, 95 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(753), new DateTime(2025, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(754), new DateTime(2025, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(749), new DateTime(2025, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(756), new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(848), new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(851), new DateTime(2025, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "MobileNumber", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(564), new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(574), "7673978319", new byte[] { 206, 146, 211, 14, 171, 171, 255, 189, 127, 93, 110, 200, 34, 137, 251, 241, 30, 142, 137, 67, 213, 75, 26, 81, 190, 178, 214, 99, 50, 93, 196, 164, 155, 207, 219, 254, 118, 18, 200, 106, 220, 202, 164, 51, 137, 5, 40, 57, 117, 165, 87, 22, 244, 91, 158, 171, 62, 125, 171, 246, 96, 15, 97, 79 }, new byte[] { 139, 124, 206, 211, 185, 67, 209, 97, 222, 203, 252, 167, 33, 178, 39, 151, 94, 15, 135, 56, 217, 154, 57, 20, 206, 97, 121, 43, 196, 186, 201, 86, 217, 190, 237, 2, 9, 1, 42, 16, 29, 51, 30, 23, 205, 222, 118, 78, 212, 37, 143, 231, 118, 75, 182, 242, 227, 172, 44, 95, 166, 21, 250, 62, 144, 135, 191, 165, 240, 62, 92, 14, 151, 227, 191, 136, 178, 13, 170, 201, 132, 78, 94, 22, 111, 77, 212, 200, 130, 33, 212, 5, 67, 95, 193, 2, 173, 87, 21, 122, 127, 67, 51, 183, 98, 167, 170, 28, 197, 74, 217, 73, 6, 70, 192, 59, 61, 15, 188, 65, 157, 236, 13, 212, 142, 110, 184, 118 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(585), new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(586), new byte[] { 206, 146, 211, 14, 171, 171, 255, 189, 127, 93, 110, 200, 34, 137, 251, 241, 30, 142, 137, 67, 213, 75, 26, 81, 190, 178, 214, 99, 50, 93, 196, 164, 155, 207, 219, 254, 118, 18, 200, 106, 220, 202, 164, 51, 137, 5, 40, 57, 117, 165, 87, 22, 244, 91, 158, 171, 62, 125, 171, 246, 96, 15, 97, 79 }, new byte[] { 139, 124, 206, 211, 185, 67, 209, 97, 222, 203, 252, 167, 33, 178, 39, 151, 94, 15, 135, 56, 217, 154, 57, 20, 206, 97, 121, 43, 196, 186, 201, 86, 217, 190, 237, 2, 9, 1, 42, 16, 29, 51, 30, 23, 205, 222, 118, 78, 212, 37, 143, 231, 118, 75, 182, 242, 227, 172, 44, 95, 166, 21, 250, 62, 144, 135, 191, 165, 240, 62, 92, 14, 151, 227, 191, 136, 178, 13, 170, 201, 132, 78, 94, 22, 111, 77, 212, 200, 130, 33, 212, 5, 67, 95, 193, 2, 173, 87, 21, 122, 127, 67, 51, 183, 98, 167, 170, 28, 197, 74, 217, 73, 6, 70, 192, 59, 61, 15, 188, 65, 157, 236, 13, 212, 142, 110, 184, 118 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(597), new DateTime(2024, 7, 31, 0, 29, 41, 861, DateTimeKind.Local).AddTicks(597), new byte[] { 206, 146, 211, 14, 171, 171, 255, 189, 127, 93, 110, 200, 34, 137, 251, 241, 30, 142, 137, 67, 213, 75, 26, 81, 190, 178, 214, 99, 50, 93, 196, 164, 155, 207, 219, 254, 118, 18, 200, 106, 220, 202, 164, 51, 137, 5, 40, 57, 117, 165, 87, 22, 244, 91, 158, 171, 62, 125, 171, 246, 96, 15, 97, 79 }, new byte[] { 139, 124, 206, 211, 185, 67, 209, 97, 222, 203, 252, 167, 33, 178, 39, 151, 94, 15, 135, 56, 217, 154, 57, 20, 206, 97, 121, 43, 196, 186, 201, 86, 217, 190, 237, 2, 9, 1, 42, 16, 29, 51, 30, 23, 205, 222, 118, 78, 212, 37, 143, 231, 118, 75, 182, 242, 227, 172, 44, 95, 166, 21, 250, 62, 144, 135, 191, 165, 240, 62, 92, 14, 151, 227, 191, 136, 178, 13, 170, 201, 132, 78, 94, 22, 111, 77, 212, 200, 130, 33, 212, 5, 67, 95, 193, 2, 173, 87, 21, 122, 127, 67, 51, 183, 98, 167, 170, 28, 197, 74, 217, 73, 6, 70, 192, 59, 61, 15, 188, 65, 157, 236, 13, 212, 142, 110, 184, 118 } });
        }
    }
}
