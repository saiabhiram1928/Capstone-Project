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
                    BasePremiumAmount = table.Column<float>(type: "real", nullable: false),
                    SchemeStartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchemeLastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTerm = table.Column<int>(type: "int", nullable: false),
                    CoverageYears = table.Column<int>(type: "int", nullable: false),
                    BaseCoverageAmount = table.Column<float>(type: "real", nullable: false)
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    QuotePaymentTerm = table.Column<int>(type: "int", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverageYears = table.Column<int>(type: "int", nullable: false),
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
                    ClaimReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AmountClaimed = table.Column<float>(type: "real", nullable: false),
                    AmountApproved = table.Column<float>(type: "real", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ClaimStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_Claims_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateEmployees_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<float>(type: "real", nullable: false),
                    PaymentDone = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
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
                columns: new[] { "SchemeId", "BaseCoverageAmount", "BasePremiumAmount", "CoverageAmount", "CoverageYears", "PaymentTerm", "RouteTitle", "SchemeDescription", "SchemeLastUpdatedAt", "SchemeName", "SchemeStartedAt", "SchemeType", "SmallDescription" },
                values: new object[,]
                {
                    { 1, 100000f, 5000f, 500000f, 10, 5, "individual-basic-plan", "The Individual Basic Plan offers essential health coverage for individuals at an affordable premium. This plan includes coverage for hospitalization, surgery, and emergency care. It is designed for those seeking fundamental protection against medical expenses.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2321), "Individual Basic Plan", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan For Every Individual Which Covers Basic Need" },
                    { 2, 250000f, 10000f, 1000000f, 15, 7, "individual-premium-plan", "The Individual Premium Plan provides extensive health coverage for individuals, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for those who want a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2326), "Individual Premium Plan", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan For Every Person Which Covers the Needs" },
                    { 3, 500000f, 20000f, 2000000f, 20, 10, "individual-elite-plan", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda voluptatem totam similique nobis dolore in, velit consectetur perspiciatis vero quas. Esse deleniti commodi perferendis officia saepe natus, quas dolor. Perspiciatis iusto nam optio quo natus amet velit explicabo quod, officia adipisci quia ipsum odio deleniti, fugiat esse illum tenetur obcaecati corporis quasi quibusdam dolorum laboriosam in. Numquam autem temporibus molestiae delectus sequi cupiditate suscipit natus facere enim dolorum sed eaque voluptas repellendus officiis et doloremque totam pariatur, quae, non amet explicabo. Maxime, magni! Ea voluptate aspernatur impedit vitae quasi necessitatibus. Ex, commodi quaerat. Dolor deleniti eos amet non. Optio minima quos incidunt recusandae eveniet, consequuntur earum quam nesciunt tenetur deserunt voluptas tempora ipsa omnis ipsam a iusto rerum, obcaecati aut nulla quo, blanditiis perferendis? Quam quo alias error possimus impedit sapiente commodi earum quaerat? Quas natus rem voluptate, at nostrum ut itaque voluptatibus porro velit labore consequatur obcaecati et nulla nihil cum, provident ratione iusto esse iure! Porro, totam cumque molestias officia minus vel molestiae, quod alias excepturi pariatur voluptates quae, cupiditate voluptatem fugit delectus. Ipsa temporibus similique odit veniam quo, cupiditate nesciunt dignissimos consequuntur aperiam, eveniet facilis recusandae voluptates nulla quaerat mollitia labore quae! Sapiente odio deserunt eum suscipit.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2329), "Individual Elite Plan", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan for Every Individual for every need" },
                    { 4, 200000f, 15000f, 1000000f, 10, 5, "corporate-standard-plan", "The Corporate Standard Plan offers essential health coverage for employees of small and medium-sized businesses. It includes hospitalization and emergency care benefits, providing basic protection to ensure the well-being of your workforce.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2330), "Corporate Standard Plan", new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "A Plan For Every Corporate Standard Covers basic need" },
                    { 5, 500000f, 30000f, 2500000f, 15, 7, "corporate-comprehensive-plan", "The Corporate Comprehensive Plan provides extensive health coverage for employees, including benefits for outpatient treatments, preventive care, and specialist consultations. This plan is designed for businesses that want to offer their employees a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2336), "Corporate Comprehensive Plan", new DateTime(2020, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "A Huge Amount Coverage For  Corporate with Higer number Of Employeess " },
                    { 6, 1000000f, 50000f, 5000000f, 20, 10, "corporate-premium-plan", "The Corporate Premium Plan offers the highest level of health coverage for corporate employees, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for businesses that seek to provide the ultimate health protection and peace of mind for their employees.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2341), "Corporate Premium Plan", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "Best Corporate Plan , with Highest Claim Sucess Rate" },
                    { 7, 200000f, 20000f, 1000000f, 10, 5, "family-basic-plan", "The Family Basic Plan offers essential health coverage for families, including hospitalization and emergency care benefits. This plan is designed to provide fundamental protection for your family’s health needs at an affordable premium.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2343), "Family Basic Plan", new DateTime(2018, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "The best plan with lowest Rate" },
                    { 8, 600000f, 40000f, 3000000f, 15, 7, "family-comprehensive-plan", "The Family Comprehensive Plan provides extensive health coverage for families, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for families seeking a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2346), "Family Comprehensive Plan", new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "Huge Amount Coverage which solves most of the needs" },
                    { 9, 1200000f, 60000f, 6000000f, 20, 10, "family-elite-plan", "The Family Elite Plan offers the highest level of health coverage for families, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for families that seek the ultimate health protection and peace of mind.", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2348), "Family Elite Plan", new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "The best Plan To Take Care of your family from every danger" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Uid", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "LastUpdated", "MobileNumber", "Password", "Role", "Salt", "Zipcode" },
                values: new object[,]
                {
                    { 101, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1879), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer1@gmail.com", "Customer", "Male", "Test", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1894), "9999999991", new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, "Customer", new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 }, "507001" },
                    { 102, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1927), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "agent@gmail.com", "Agent", "Male", "Test", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1927), "9999999999", new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, "Agent", new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 }, "507002" },
                    { 103, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1953), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "Male", "Test", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(1954), "111111111", new byte[] { 202, 165, 132, 102, 100, 167, 250, 128, 208, 130, 223, 94, 150, 69, 65, 54, 33, 80, 148, 236, 48, 88, 41, 80, 36, 154, 201, 4, 249, 112, 75, 218, 2, 95, 162, 78, 210, 154, 144, 118, 179, 166, 145, 22, 32, 195, 25, 9, 148, 14, 120, 32, 76, 210, 131, 118, 55, 24, 57, 52, 187, 128, 1, 82 }, "Admin", new byte[] { 248, 186, 113, 45, 169, 78, 141, 0, 77, 244, 70, 144, 80, 86, 194, 26, 22, 75, 110, 202, 201, 131, 56, 132, 124, 127, 43, 210, 197, 38, 167, 109, 56, 182, 46, 166, 185, 231, 143, 71, 175, 35, 61, 218, 212, 188, 87, 192, 3, 149, 93, 207, 95, 50, 217, 78, 46, 161, 220, 47, 227, 72, 214, 243, 86, 67, 48, 101, 165, 182, 254, 209, 43, 223, 252, 181, 159, 28, 252, 240, 9, 224, 214, 178, 166, 252, 81, 52, 227, 153, 90, 127, 194, 7, 104, 39, 217, 74, 87, 184, 109, 180, 166, 157, 0, 67, 7, 236, 27, 96, 180, 226, 29, 60, 136, 141, 29, 36, 210, 243, 125, 54, 220, 183, 53, 89, 83, 80 }, "507003" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Uid" },
                values: new object[] { 1, 103 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "EmergenceyContact", "Uid" },
                values: new object[] { 10001, "888888888", 101 });

            migrationBuilder.InsertData(
                table: "HospitalAgents",
                columns: new[] { "AgentId", "AgentContact", "HosiptalId", "Uid" },
                values: new object[] { 11111, "7000001111", 1, 102 });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "CoverageYears", "CustomerId", "LastPaymentDate", "NextPaymentDueDate", "PaymentFrequency", "PolicyEndDate", "PolicyExpiryDate", "PolicyStartDate", "PremiumAmount", "QuoteAmount", "QuotePaymentTerm", "RenewalStatus", "SchemeId" },
                values: new object[] { 1, 0, 10001, new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2285), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2287), "Quarterly", new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2280), new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2291), new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2280), 500f, 1000f, 0, "Renwed", 1 });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "ClaimId", "AcceptedDate", "AmountApproved", "AmountClaimed", "ApprovedBy", "ClaimReason", "ClaimStatus", "ClaimedDate", "CustomerId", "PolicyId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500f, 2000f, 1, "Hosiptal Bills", "Approved", new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2386), 10001, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CustomerId", "PaymentAmount", "PaymentDate", "PaymentDone", "PaymentDueDate", "PaymentStatus", "PaymentType", "PolicyId", "Remarks", "TransactionId" },
                values: new object[] { 10001, 10001, 500f, new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2525), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 0, 1, "First payment of the year", 100001 });

            migrationBuilder.InsertData(
                table: "Renewals",
                columns: new[] { "RenewalId", "CustomerId", "DiscountApplied", "NewPolicyStartDate", "PolicyId", "RenewalDate", "RenewalStatus" },
                values: new object[,]
                {
                    { 1, 10001, 0f, new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2555), 1, new DateTime(2024, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2555), "Pending" },
                    { 2, 10001, 100f, new DateTime(2026, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2558), 1, new DateTime(2025, 8, 2, 11, 42, 21, 4, DateTimeKind.Local).AddTicks(2558), "Renwed" }
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
                name: "IX_Claims_PolicyId",
                table: "Claims",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateEmployees_PolicyId",
                table: "CorporateEmployees",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Uid",
                table: "Customers",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_PolicyId",
                table: "FamilyMembers",
                column: "PolicyId");

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
                column: "SchemeId");

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
                name: "CorporateEmployees");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "HospitalAgents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Renewals");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Hosiptals");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
