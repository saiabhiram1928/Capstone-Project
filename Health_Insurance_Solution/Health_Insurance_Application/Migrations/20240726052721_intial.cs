using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance_Application.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hosiptals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosiptals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    SchemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchemeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchemeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverageAmount = table.Column<float>(type: "real", nullable: false),
                    SchemeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePremiumAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.SchemeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Uid",
                        column: x => x.Uid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergenceyContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_Uid",
                        column: x => x.Uid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalAgents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<int>(type: "int", nullable: false),
                    AgentContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HosiptalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAgents", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_HospitalAgents_Hosiptals_HosiptalId",
                        column: x => x.HosiptalId,
                        principalTable: "Hosiptals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalAgents_Users_Uid",
                        column: x => x.Uid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SchemeId = table.Column<int>(type: "int", nullable: false),
                    PolicyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumAmount = table.Column<float>(type: "real", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteAmount = table.Column<float>(type: "real", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RenewalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policies_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policies_Schemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Schemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    HospitalAgentId = table.Column<int>(type: "int", nullable: false),
                    AmountClaimed = table.Column<float>(type: "real", nullable: false),
                    AmountApproved = table.Column<float>(type: "real", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ClaimStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Admins_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_Claims_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claims_HospitalAgents_HospitalAgentId",
                        column: x => x.HospitalAgentId,
                        principalTable: "HospitalAgents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claims_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renewals",
                columns: table => new
                {
                    RenewalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RenewalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewPolicyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewPremiumAmount = table.Column<float>(type: "real", nullable: false),
                    NewPaymentFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountApplied = table.Column<float>(type: "real", nullable: false),
                    RenewalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renewals", x => x.RenewalId);
                    table.ForeignKey(
                        name: "FK_Renewals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renewals_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hosiptals",
                columns: new[] { "Id", "BranchCode", "City", "Name", "State", "Street", "Zipcode" },
                values: new object[] { 1, "Kmm05", "Khammam", "Hosiptal A", "Telangana", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 507001 });

            migrationBuilder.InsertData(
                table: "Schemes",
                columns: new[] { "SchemeId", "BasePremiumAmount", "CoverageAmount", "SchemeDescription", "SchemeName", "SchemeType" },
                values: new object[,]
                {
                    { 1, 500f, 10000f, "Provides basic health coverage.", "Basic Health Plan", "Individual" },
                    { 2, 750f, 25000f, "Provides health coverage for families.", "Family Health Plan", "Family" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Uid", "City", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdated", "MobileNumber", "Password", "Role", "Salt", "State", "Street", "Zipcode" },
                values: new object[,]
                {
                    { 101, "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2208), "customer1@gmail.com", "Customer", "Test", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2227), "7673978319", new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, "Customer", new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "Test Lorem , blaaa", "507001" },
                    { 102, "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2247), "agent@gmail.com", "Agent", "Test", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2248), "9999999999", new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, "Agent", new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "Test lorem , fam", "507002" },
                    { 103, "Springfield", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2323), "admin@gmail.com", "Admin", "Test", new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2323), "111111111", new byte[] { 17, 251, 9, 14, 233, 201, 13, 115, 36, 179, 112, 37, 192, 167, 166, 156, 178, 46, 40, 94, 191, 75, 25, 152, 160, 140, 160, 39, 213, 106, 170, 9, 246, 12, 186, 149, 40, 50, 125, 239, 100, 249, 86, 176, 22, 84, 165, 102, 132, 155, 26, 228, 217, 133, 160, 190, 151, 229, 4, 198, 184, 209, 217, 199 }, "Admin", new byte[] { 4, 140, 201, 167, 93, 180, 5, 31, 224, 11, 247, 51, 241, 158, 144, 165, 127, 180, 190, 42, 138, 243, 134, 202, 144, 203, 186, 77, 245, 82, 110, 241, 12, 194, 101, 81, 246, 90, 220, 76, 171, 154, 220, 127, 215, 115, 13, 75, 134, 23, 58, 101, 232, 60, 242, 193, 54, 58, 231, 138, 119, 27, 62, 229, 130, 111, 242, 10, 222, 49, 140, 48, 111, 12, 90, 14, 123, 5, 83, 193, 150, 35, 89, 164, 60, 198, 44, 246, 29, 133, 126, 82, 27, 171, 105, 36, 38, 244, 252, 178, 76, 105, 27, 154, 8, 173, 73, 131, 81, 229, 210, 63, 155, 28, 200, 43, 233, 31, 145, 242, 224, 196, 249, 230, 194, 151, 33, 99 }, "IL", "789 Oak St", "507003" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Uid" },
                values: new object[] { 1, 103 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DateOfBirth", "EmergenceyContact", "Gender", "Uid" },
                values: new object[] { 10001, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "888888888", "Male", 101 });

            migrationBuilder.InsertData(
                table: "HospitalAgents",
                columns: new[] { "AgentId", "AgentContact", "HosiptalId", "Uid" },
                values: new object[] { 11111, "7000001111", 1, 102 });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "CustomerId", "LastPaymentDate", "NextPaymentDueDate", "PaymentFrequency", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate", "PremiumAmount", "QuoteAmount", "RenewalStatus", "SchemeId" },
                values: new object[] { 1, 10001, new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2545), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2545), "Quarterly", new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2540), new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2548), new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2539), 500f, 1000f, "Renwed", 1 });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "ClaimId", "AmountApproved", "AmountClaimed", "ApprovedBy", "ClaimStatus", "CustomerId", "HospitalAgentId", "PolicyId" },
                values: new object[] { 1, 1500f, 2000f, 1, "Approved", 10001, 11111, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "TransactionId", "CustomerId", "PaymentAmount", "PaymentDate", "PaymentStatus", "PolicyId", "Remarks" },
                values: new object[] { 1, 10001, 500f, new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2684), "Completed", 1, "First payment of the year" });

            migrationBuilder.InsertData(
                table: "Renewals",
                columns: new[] { "RenewalId", "CustomerId", "DiscountApplied", "NewPaymentFrequency", "NewPolicyStartDate", "NewPremiumAmount", "PolicyId", "RenewalDate", "RenewalStatus" },
                values: new object[,]
                {
                    { 1, 10001, 0f, "Anually", new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2698), 550f, 1, new DateTime(2024, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2697), "Pending" },
                    { 2, 10001, 100f, "Quarterly", new DateTime(2026, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2700), 800f, 1, new DateTime(2025, 7, 26, 10, 57, 20, 645, DateTimeKind.Local).AddTicks(2700), "Renwed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Uid",
                table: "Admins",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ApprovedBy",
                table: "Claims",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CustomerId",
                table: "Claims",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_HospitalAgentId",
                table: "Claims",
                column: "HospitalAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Uid",
                table: "Customers",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAgents_HosiptalId",
                table: "HospitalAgents",
                column: "HosiptalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAgents_Uid",
                table: "HospitalAgents",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PolicyId",
                table: "Payments",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CustomerId",
                table: "Policies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_SchemeId",
                table: "Policies",
                column: "SchemeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Renewals_CustomerId",
                table: "Renewals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Renewals_PolicyId",
                table: "Renewals",
                column: "PolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Renewals");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "HospitalAgents");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Hosiptals");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
