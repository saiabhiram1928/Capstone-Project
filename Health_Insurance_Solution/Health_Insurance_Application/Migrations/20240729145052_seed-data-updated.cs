using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class seeddataupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmallDescription",
                table: "Schemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "PaymentDate",
                value: new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDueDate", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4488), new DateTime(2025, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4488), new DateTime(2025, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4484), new DateTime(2025, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4481) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 1,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2025, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4586), new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Renewals",
                keyColumn: "RenewalId",
                keyValue: 2,
                columns: new[] { "NewPolicyStartDate", "RenewalDate" },
                values: new object[] { new DateTime(2026, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4588), new DateTime(2025, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 1,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4504), "A Plan For Every Individual Which Covers Basic Need" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4507), "A Plan For Every Person Which Covers the Needs" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4508), "A Plan for Every Individual for every need" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4510), "A Plan For Every Corporate Standard Covers basic need" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4511), "A Huge Amount Coverage For  Corporate with Higer number Of Employeess " });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4512), "Best Corporate Plan , with Highest Claim Sucess Rate" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4514), "The best plan with lowest Rate" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4516), "Huge Amount Coverage which solves most of the needs" });

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                columns: new[] { "SchemeLastUpdatedAt", "SmallDescription" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4517), "The best Plan To Take Care of your family from every danger" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 101,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4152), new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4170), new byte[] { 138, 69, 185, 148, 29, 252, 250, 247, 163, 59, 130, 79, 223, 215, 84, 175, 92, 176, 186, 24, 137, 153, 143, 159, 152, 13, 183, 31, 17, 4, 113, 225, 84, 32, 107, 31, 84, 126, 60, 98, 188, 81, 23, 64, 93, 48, 89, 62, 113, 121, 187, 40, 157, 52, 176, 136, 90, 242, 248, 148, 16, 83, 220, 33 }, new byte[] { 96, 15, 165, 245, 181, 107, 82, 139, 136, 205, 131, 197, 196, 172, 241, 91, 248, 220, 91, 86, 198, 39, 230, 223, 129, 102, 193, 15, 203, 89, 12, 128, 74, 98, 232, 186, 97, 197, 138, 28, 88, 25, 49, 231, 56, 121, 14, 214, 46, 74, 131, 9, 187, 86, 34, 129, 167, 159, 52, 243, 173, 127, 83, 72, 50, 35, 89, 78, 228, 252, 83, 13, 211, 27, 68, 109, 240, 142, 247, 19, 213, 29, 210, 149, 26, 20, 84, 128, 83, 212, 212, 61, 38, 153, 124, 4, 0, 211, 22, 75, 205, 177, 76, 208, 32, 200, 147, 196, 91, 111, 247, 165, 242, 69, 226, 77, 217, 127, 18, 141, 223, 94, 191, 151, 65, 101, 232, 180 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 102,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4190), new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4191), new byte[] { 138, 69, 185, 148, 29, 252, 250, 247, 163, 59, 130, 79, 223, 215, 84, 175, 92, 176, 186, 24, 137, 153, 143, 159, 152, 13, 183, 31, 17, 4, 113, 225, 84, 32, 107, 31, 84, 126, 60, 98, 188, 81, 23, 64, 93, 48, 89, 62, 113, 121, 187, 40, 157, 52, 176, 136, 90, 242, 248, 148, 16, 83, 220, 33 }, new byte[] { 96, 15, 165, 245, 181, 107, 82, 139, 136, 205, 131, 197, 196, 172, 241, 91, 248, 220, 91, 86, 198, 39, 230, 223, 129, 102, 193, 15, 203, 89, 12, 128, 74, 98, 232, 186, 97, 197, 138, 28, 88, 25, 49, 231, 56, 121, 14, 214, 46, 74, 131, 9, 187, 86, 34, 129, 167, 159, 52, 243, 173, 127, 83, 72, 50, 35, 89, 78, 228, 252, 83, 13, 211, 27, 68, 109, 240, 142, 247, 19, 213, 29, 210, 149, 26, 20, 84, 128, 83, 212, 212, 61, 38, 153, 124, 4, 0, 211, 22, 75, 205, 177, 76, 208, 32, 200, 147, 196, 91, 111, 247, 165, 242, 69, 226, 77, 217, 127, 18, 141, 223, 94, 191, 151, 65, 101, 232, 180 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uid",
                keyValue: 103,
                columns: new[] { "CreatedAt", "LastUpdated", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4209), new DateTime(2024, 7, 29, 20, 20, 51, 764, DateTimeKind.Local).AddTicks(4209), new byte[] { 138, 69, 185, 148, 29, 252, 250, 247, 163, 59, 130, 79, 223, 215, 84, 175, 92, 176, 186, 24, 137, 153, 143, 159, 152, 13, 183, 31, 17, 4, 113, 225, 84, 32, 107, 31, 84, 126, 60, 98, 188, 81, 23, 64, 93, 48, 89, 62, 113, 121, 187, 40, 157, 52, 176, 136, 90, 242, 248, 148, 16, 83, 220, 33 }, new byte[] { 96, 15, 165, 245, 181, 107, 82, 139, 136, 205, 131, 197, 196, 172, 241, 91, 248, 220, 91, 86, 198, 39, 230, 223, 129, 102, 193, 15, 203, 89, 12, 128, 74, 98, 232, 186, 97, 197, 138, 28, 88, 25, 49, 231, 56, 121, 14, 214, 46, 74, 131, 9, 187, 86, 34, 129, 167, 159, 52, 243, 173, 127, 83, 72, 50, 35, 89, 78, 228, 252, 83, 13, 211, 27, 68, 109, 240, 142, 247, 19, 213, 29, 210, 149, 26, 20, 84, 128, 83, 212, 212, 61, 38, 153, 124, 4, 0, 211, 22, 75, 205, 177, 76, 208, 32, 200, 147, 196, 91, 111, 247, 165, 242, 69, 226, 77, 217, 127, 18, 141, 223, 94, 191, 151, 65, 101, 232, 180 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallDescription",
                table: "Schemes");

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
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 2,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 3,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 4,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 5,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 6,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 7,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 8,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Schemes",
                keyColumn: "SchemeId",
                keyValue: 9,
                column: "SchemeLastUpdatedAt",
                value: new DateTime(2024, 7, 29, 17, 7, 57, 192, DateTimeKind.Local).AddTicks(8629));

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
    }
}
