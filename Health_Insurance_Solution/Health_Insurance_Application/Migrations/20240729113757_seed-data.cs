using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8598), new DateTime(2025, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8599), new DateTime(2025, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8592), new DateTime(2025, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8601), new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8591) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8758), new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8760), new DateTime(2025, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 100000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 250000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 500000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 200000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 500000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 1000000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 200000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8626) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 600000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 1200000f, new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8401), new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8415), new byte[] { 29, 250, 211, 152, 167, 202, 58, 250, 123, 12, 150, 122, 138, 85, 245, 124, 130, 89, 118, 198, 189, 37, 121, 57, 5, 41, 60, 223, 177, 68, 2, 63, 250, 208, 70, 77, 2, 49, 181, 177, 118, 205, 57, 195, 70, 220, 80, 200, 155, 52, 113, 133, 74, 216, 19, 165, 86, 191, 87, 130, 79, 161, 213, 196 }, new byte[] { 78, 80, 54, 254, 99, 210, 167, 202, 242, 28, 222, 13, 110, 73, 28, 53, 222, 46, 40, 194, 244, 31, 55, 234, 68, 180, 190, 65, 250, 192, 59, 181, 86, 107, 60, 64, 81, 198, 141, 233, 94, 27, 112, 72, 214, 156, 205, 182, 70, 250, 219, 254, 72, 165, 48, 137, 156, 23, 26, 254, 140, 24, 39, 254, 68, 67, 185, 252, 47, 217, 91, 77, 149, 12, 89, 228, 227, 55, 73, 27, 97, 212, 215, 49, 224, 76, 130, 64, 106, 22, 87, 209, 121, 90, 194, 196, 233, 30, 113, 223, 42, 192, 59, 62, 49, 36, 93, 204, 159, 169, 142, 22, 221, 69, 91, 200, 146, 184, 157, 91, 57, 80, 125, 35, 3, 73, 127, 24 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8428), new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8429), new byte[] { 29, 250, 211, 152, 167, 202, 58, 250, 123, 12, 150, 122, 138, 85, 245, 124, 130, 89, 118, 198, 189, 37, 121, 57, 5, 41, 60, 223, 177, 68, 2, 63, 250, 208, 70, 77, 2, 49, 181, 177, 118, 205, 57, 195, 70, 220, 80, 200, 155, 52, 113, 133, 74, 216, 19, 165, 86, 191, 87, 130, 79, 161, 213, 196 }, new byte[] { 78, 80, 54, 254, 99, 210, 167, 202, 242, 28, 222, 13, 110, 73, 28, 53, 222, 46, 40, 194, 244, 31, 55, 234, 68, 180, 190, 65, 250, 192, 59, 181, 86, 107, 60, 64, 81, 198, 141, 233, 94, 27, 112, 72, 214, 156, 205, 182, 70, 250, 219, 254, 72, 165, 48, 137, 156, 23, 26, 254, 140, 24, 39, 254, 68, 67, 185, 252, 47, 217, 91, 77, 149, 12, 89, 228, 227, 55, 73, 27, 97, 212, 215, 49, 224, 76, 130, 64, 106, 22, 87, 209, 121, 90, 194, 196, 233, 30, 113, 223, 42, 192, 59, 62, 49, 36, 93, 204, 159, 169, 142, 22, 221, 69, 91, 200, 146, 184, 157, 91, 57, 80, 125, 35, 3, 73, 127, 24 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8439), new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8440), new byte[] { 29, 250, 211, 152, 167, 202, 58, 250, 123, 12, 150, 122, 138, 85, 245, 124, 130, 89, 118, 198, 189, 37, 121, 57, 5, 41, 60, 223, 177, 68, 2, 63, 250, 208, 70, 77, 2, 49, 181, 177, 118, 205, 57, 195, 70, 220, 80, 200, 155, 52, 113, 133, 74, 216, 19, 165, 86, 191, 87, 130, 79, 161, 213, 196 }, new byte[] { 78, 80, 54, 254, 99, 210, 167, 202, 242, 28, 222, 13, 110, 73, 28, 53, 222, 46, 40, 194, 244, 31, 55, 234, 68, 180, 190, 65, 250, 192, 59, 181, 86, 107, 60, 64, 81, 198, 141, 233, 94, 27, 112, 72, 214, 156, 205, 182, 70, 250, 219, 254, 72, 165, 48, 137, 156, 23, 26, 254, 140, 24, 39, 254, 68, 67, 185, 252, 47, 217, 91, 77, 149, 12, 89, 228, 227, 55, 73, 27, 97, 212, 215, 49, 224, 76, 130, 64, 106, 22, 87, 209, 121, 90, 194, 196, 233, 30, 113, 223, 42, 192, 59, 62, 49, 36, 93, 204, 159, 169, 142, 22, 221, 69, 91, 200, 146, 184, 157, 91, 57, 80, 125, 35, 3, 73, 127, 24 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(255), new DateTime(2025, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(256), new DateTime(2025, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(251), new DateTime(2025, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(258), new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(367), new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(370), new DateTime(2025, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(369) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(274) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(277) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(281) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                columns: new[] { "BaseCoverageAmount", "SchemeLastUpdatedAt" },
                values: new object[] { 0f, new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 16, 50, 55, 19, DateTimeKind.Local).AddTicks(9976), new DateTime(2024, 7, 29, 16, 50, 55, 19, DateTimeKind.Local).AddTicks(9990), new byte[] { 31, 48, 240, 67, 136, 12, 228, 16, 228, 156, 47, 142, 213, 57, 196, 3, 13, 164, 220, 6, 86, 142, 19, 21, 229, 56, 162, 40, 128, 34, 137, 187, 184, 186, 200, 41, 89, 208, 170, 87, 231, 87, 44, 222, 75, 229, 86, 34, 12, 50, 239, 43, 247, 108, 95, 42, 230, 30, 44, 176, 160, 170, 190, 54 }, new byte[] { 76, 17, 5, 245, 149, 98, 220, 80, 19, 182, 238, 5, 1, 167, 18, 17, 63, 44, 3, 254, 62, 9, 127, 173, 248, 233, 145, 9, 238, 81, 78, 196, 178, 31, 176, 134, 214, 46, 235, 90, 34, 109, 104, 6, 73, 235, 19, 17, 41, 251, 151, 219, 26, 240, 13, 228, 37, 102, 132, 91, 69, 222, 181, 41, 84, 8, 1, 219, 71, 103, 119, 118, 148, 147, 222, 229, 254, 204, 222, 188, 226, 69, 13, 100, 253, 212, 121, 81, 88, 248, 77, 207, 152, 55, 134, 225, 177, 209, 100, 141, 182, 54, 148, 207, 17, 186, 67, 34, 124, 117, 236, 58, 253, 142, 167, 92, 106, 104, 57, 224, 52, 247, 164, 232, 77, 66, 126, 204 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(2), new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(3), new byte[] { 31, 48, 240, 67, 136, 12, 228, 16, 228, 156, 47, 142, 213, 57, 196, 3, 13, 164, 220, 6, 86, 142, 19, 21, 229, 56, 162, 40, 128, 34, 137, 187, 184, 186, 200, 41, 89, 208, 170, 87, 231, 87, 44, 222, 75, 229, 86, 34, 12, 50, 239, 43, 247, 108, 95, 42, 230, 30, 44, 176, 160, 170, 190, 54 }, new byte[] { 76, 17, 5, 245, 149, 98, 220, 80, 19, 182, 238, 5, 1, 167, 18, 17, 63, 44, 3, 254, 62, 9, 127, 173, 248, 233, 145, 9, 238, 81, 78, 196, 178, 31, 176, 134, 214, 46, 235, 90, 34, 109, 104, 6, 73, 235, 19, 17, 41, 251, 151, 219, 26, 240, 13, 228, 37, 102, 132, 91, 69, 222, 181, 41, 84, 8, 1, 219, 71, 103, 119, 118, 148, 147, 222, 229, 254, 204, 222, 188, 226, 69, 13, 100, 253, 212, 121, 81, 88, 248, 77, 207, 152, 55, 134, 225, 177, 209, 100, 141, 182, 54, 148, 207, 17, 186, 67, 34, 124, 117, 236, 58, 253, 142, 167, 92, 106, 104, 57, 224, 52, 247, 164, 232, 77, 66, 126, 204 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(13), new DateTime(2024, 7, 29, 16, 50, 55, 20, DateTimeKind.Local).AddTicks(14), new byte[] { 31, 48, 240, 67, 136, 12, 228, 16, 228, 156, 47, 142, 213, 57, 196, 3, 13, 164, 220, 6, 86, 142, 19, 21, 229, 56, 162, 40, 128, 34, 137, 187, 184, 186, 200, 41, 89, 208, 170, 87, 231, 87, 44, 222, 75, 229, 86, 34, 12, 50, 239, 43, 247, 108, 95, 42, 230, 30, 44, 176, 160, 170, 190, 54 }, new byte[] { 76, 17, 5, 245, 149, 98, 220, 80, 19, 182, 238, 5, 1, 167, 18, 17, 63, 44, 3, 254, 62, 9, 127, 173, 248, 233, 145, 9, 238, 81, 78, 196, 178, 31, 176, 134, 214, 46, 235, 90, 34, 109, 104, 6, 73, 235, 19, 17, 41, 251, 151, 219, 26, 240, 13, 228, 37, 102, 132, 91, 69, 222, 181, 41, 84, 8, 1, 219, 71, 103, 119, 118, 148, 147, 222, 229, 254, 204, 222, 188, 226, 69, 13, 100, 253, 212, 121, 81, 88, 248, 77, 207, 152, 55, 134, 225, 177, 209, 100, 141, 182, 54, 148, 207, 17, 186, 67, 34, 124, 117, 236, 58, 253, 142, 167, 92, 106, 104, 57, 224, 52, 247, 164, 232, 77, 66, 126, 204 } });
        }
    }
}
