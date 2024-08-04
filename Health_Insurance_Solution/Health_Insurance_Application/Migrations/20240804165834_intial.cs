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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "SchemeId", "BaseCoverageAmount", "BasePremiumAmount", "CoverageAmount", "CoverageYears", "IsActive", "PaymentTerm", "RouteTitle", "SchemeDescription", "SchemeLastUpdatedAt", "SchemeName", "SchemeStartedAt", "SchemeType", "SmallDescription" },
                values: new object[,]
                {
                    { 1, 100000f, 5000f, 500000f, 10, true, 5, "individual-basic-plan", "The Individual Basic Plan offers essential health coverage for individuals at an affordable premium. This plan includes coverage for hospitalization, surgery, and emergency care. It is designed for those seeking fundamental protection against medical expenses.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1854), "Individual Basic Plan", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan For Every Individual Which Covers Basic Need" },
                    { 2, 250000f, 10000f, 1000000f, 15, true, 7, "individual-premium-plan", "The Individual Premium Plan provides extensive health coverage for individuals, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for those who want a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1857), "Individual Premium Plan", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan For Every Person Which Covers the Needs" },
                    { 3, 500000f, 20000f, 2000000f, 20, true, 10, "individual-elite-plan", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda voluptatem totam similique nobis dolore in, velit consectetur perspiciatis vero quas. Esse deleniti commodi perferendis officia saepe natus, quas dolor. Perspiciatis iusto nam optio quo natus amet velit explicabo quod, officia adipisci quia ipsum odio deleniti, fugiat esse illum tenetur obcaecati corporis quasi quibusdam dolorum laboriosam in. Numquam autem temporibus molestiae delectus sequi cupiditate suscipit natus facere enim dolorum sed eaque voluptas repellendus officiis et doloremque totam pariatur, quae, non amet explicabo. Maxime, magni! Ea voluptate aspernatur impedit vitae quasi necessitatibus. Ex, commodi quaerat. Dolor deleniti eos amet non. Optio minima quos incidunt recusandae eveniet, consequuntur earum quam nesciunt tenetur deserunt voluptas tempora ipsa omnis ipsam a iusto rerum, obcaecati aut nulla quo, blanditiis perferendis? Quam quo alias error possimus impedit sapiente commodi earum quaerat? Quas natus rem voluptate, at nostrum ut itaque voluptatibus porro velit labore consequatur obcaecati et nulla nihil cum, provident ratione iusto esse iure! Porro, totam cumque molestias officia minus vel molestiae, quod alias excepturi pariatur voluptates quae, cupiditate voluptatem fugit delectus. Ipsa temporibus similique odit veniam quo, cupiditate nesciunt dignissimos consequuntur aperiam, eveniet facilis recusandae voluptates nulla quaerat mollitia labore quae! Sapiente odio deserunt eum suscipit.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1860), "Individual Elite Plan", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual", "A Plan for Every Individual for every need" },
                    { 4, 200000f, 15000f, 1000000f, 10, true, 5, "corporate-standard-plan", "The Corporate Standard Plan offers essential health coverage for employees of small and medium-sized businesses. It includes hospitalization and emergency care benefits, providing basic protection to ensure the well-being of your workforce.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1861), "Corporate Standard Plan", new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "A Plan For Every Corporate Standard Covers basic need" },
                    { 5, 500000f, 30000f, 2500000f, 15, true, 7, "corporate-comprehensive-plan", "The Corporate Comprehensive Plan provides extensive health coverage for employees, including benefits for outpatient treatments, preventive care, and specialist consultations. This plan is designed for businesses that want to offer their employees a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1863), "Corporate Comprehensive Plan", new DateTime(2020, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "A Huge Amount Coverage For  Corporate with Higer number Of Employeess " },
                    { 6, 1000000f, 50000f, 5000000f, 20, true, 10, "corporate-premium-plan", "The Corporate Premium Plan offers the highest level of health coverage for corporate employees, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for businesses that seek to provide the ultimate health protection and peace of mind for their employees.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1864), "Corporate Premium Plan", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "Best Corporate Plan , with Highest Claim Sucess Rate" },
                    { 7, 200000f, 20000f, 1000000f, 10, true, 5, "family-basic-plan", "The Family Basic Plan offers essential health coverage for families, including hospitalization and emergency care benefits. This plan is designed to provide fundamental protection for your family’s health needs at an affordable premium.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1865), "Family Basic Plan", new DateTime(2018, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "The best plan with lowest Rate" },
                    { 8, 600000f, 40000f, 3000000f, 15, true, 7, "family-comprehensive-plan", "The Family Comprehensive Plan provides extensive health coverage for families, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for families seeking a higher level of health security and comprehensive medical benefits.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1867), "Family Comprehensive Plan", new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "Huge Amount Coverage which solves most of the needs" },
                    { 9, 1200000f, 60000f, 6000000f, 20, true, 10, "family-elite-plan", "The Family Elite Plan offers the highest level of health coverage for families, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for families that seek the ultimate health protection and peace of mind.", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1868), "Family Elite Plan", new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family", "The best Plan To Take Care of your family from every danger" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Uid", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "LastUpdated", "MobileNumber", "Password", "Role", "Salt", "Zipcode" },
                values: new object[,]
                {
                    { 101, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1567), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer1@gmail.com", "Customer", "Male", "Test", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1581), "9999999991", new byte[] { 28, 248, 127, 178, 14, 176, 11, 149, 110, 164, 118, 167, 132, 57, 102, 214, 102, 99, 144, 100, 36, 250, 72, 14, 186, 138, 194, 114, 13, 131, 174, 205, 81, 234, 141, 92, 53, 189, 50, 76, 168, 32, 212, 233, 40, 244, 164, 103, 247, 214, 13, 108, 233, 75, 78, 16, 59, 33, 213, 127, 154, 13, 203, 102 }, "Customer", new byte[] { 18, 96, 128, 56, 232, 230, 205, 14, 58, 36, 138, 172, 208, 52, 151, 131, 45, 184, 81, 208, 152, 79, 143, 161, 128, 129, 253, 203, 237, 152, 129, 204, 243, 126, 116, 175, 96, 26, 153, 185, 196, 210, 198, 234, 210, 100, 46, 69, 11, 68, 81, 67, 87, 207, 11, 82, 195, 26, 4, 182, 125, 243, 55, 182, 115, 132, 98, 205, 144, 137, 223, 211, 101, 88, 117, 157, 21, 38, 235, 125, 237, 130, 129, 252, 216, 95, 211, 247, 143, 3, 91, 4, 229, 31, 8, 4, 49, 127, 82, 8, 127, 61, 9, 89, 207, 46, 109, 101, 13, 0, 112, 17, 144, 72, 79, 132, 203, 134, 67, 199, 12, 13, 207, 100, 2, 253, 25, 98 }, "507001" },
                    { 102, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1600), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "agent@gmail.com", "Agent", "Male", "Test", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1600), "9999999999", new byte[] { 28, 248, 127, 178, 14, 176, 11, 149, 110, 164, 118, 167, 132, 57, 102, 214, 102, 99, 144, 100, 36, 250, 72, 14, 186, 138, 194, 114, 13, 131, 174, 205, 81, 234, 141, 92, 53, 189, 50, 76, 168, 32, 212, 233, 40, 244, 164, 103, 247, 214, 13, 108, 233, 75, 78, 16, 59, 33, 213, 127, 154, 13, 203, 102 }, "Agent", new byte[] { 18, 96, 128, 56, 232, 230, 205, 14, 58, 36, 138, 172, 208, 52, 151, 131, 45, 184, 81, 208, 152, 79, 143, 161, 128, 129, 253, 203, 237, 152, 129, 204, 243, 126, 116, 175, 96, 26, 153, 185, 196, 210, 198, 234, 210, 100, 46, 69, 11, 68, 81, 67, 87, 207, 11, 82, 195, 26, 4, 182, 125, 243, 55, 182, 115, 132, 98, 205, 144, 137, 223, 211, 101, 88, 117, 157, 21, 38, 235, 125, 237, 130, 129, 252, 216, 95, 211, 247, 143, 3, 91, 4, 229, 31, 8, 4, 49, 127, 82, 8, 127, 61, 9, 89, 207, 46, 109, 101, 13, 0, 112, 17, 144, 72, 79, 132, 203, 134, 67, 199, 12, 13, 207, 100, 2, 253, 25, 98 }, "507002" },
                    { 103, "St Street opp lalbagh, chennai , TamilNadu", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1661), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "Male", "Test", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1662), "111111111", new byte[] { 28, 248, 127, 178, 14, 176, 11, 149, 110, 164, 118, 167, 132, 57, 102, 214, 102, 99, 144, 100, 36, 250, 72, 14, 186, 138, 194, 114, 13, 131, 174, 205, 81, 234, 141, 92, 53, 189, 50, 76, 168, 32, 212, 233, 40, 244, 164, 103, 247, 214, 13, 108, 233, 75, 78, 16, 59, 33, 213, 127, 154, 13, 203, 102 }, "Admin", new byte[] { 18, 96, 128, 56, 232, 230, 205, 14, 58, 36, 138, 172, 208, 52, 151, 131, 45, 184, 81, 208, 152, 79, 143, 161, 128, 129, 253, 203, 237, 152, 129, 204, 243, 126, 116, 175, 96, 26, 153, 185, 196, 210, 198, 234, 210, 100, 46, 69, 11, 68, 81, 67, 87, 207, 11, 82, 195, 26, 4, 182, 125, 243, 55, 182, 115, 132, 98, 205, 144, 137, 223, 211, 101, 88, 117, 157, 21, 38, 235, 125, 237, 130, 129, 252, 216, 95, 211, 247, 143, 3, 91, 4, 229, 31, 8, 4, 49, 127, 82, 8, 127, 61, 9, 89, 207, 46, 109, 101, 13, 0, 112, 17, 144, 72, 79, 132, 203, 134, 67, 199, 12, 13, 207, 100, 2, 253, 25, 98 }, "507003" }
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
                values: new object[] { 1, 0, 10001, new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1832), new DateTime(2025, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1833), "Quarterly", new DateTime(2025, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1829), new DateTime(2025, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1835), new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1828), 500f, 1000f, 0, "Renwed", 1 });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "ClaimId", "AcceptedDate", "AmountApproved", "AmountClaimed", "ApprovedBy", "ClaimReason", "ClaimStatus", "ClaimedDate", "CustomerId", "PolicyId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500f, 2000f, 1, "Hosiptal Bills", "Approved", new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1891), 10001, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CustomerId", "PaymentAmount", "PaymentDate", "PaymentDone", "PaymentDueDate", "PaymentStatus", "PaymentType", "PolicyId", "Remarks", "TransactionId" },
                values: new object[] { 10001, 10001, 500f, new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1936), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 0, 1, "First payment of the year", 100001 });

            migrationBuilder.InsertData(
                table: "Renewals",
                columns: new[] { "RenewalId", "CustomerId", "DiscountApplied", "NewPolicyStartDate", "PolicyId", "RenewalDate", "RenewalStatus" },
                values: new object[,]
                {
                    { 1, 10001, 0f, new DateTime(2025, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1952), 1, new DateTime(2024, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1952), "Pending" },
                    { 2, 10001, 100f, new DateTime(2026, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1956), 1, new DateTime(2025, 8, 4, 22, 28, 34, 248, DateTimeKind.Local).AddTicks(1955), "Renwed" }
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
