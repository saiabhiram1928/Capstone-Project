using Health_Insurance_Application.Models;
using Health_Insurance_Application.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography;
using System.Text;

namespace Health_Insurance_Application.Context
{
    public class HealthInsuranceContext : DbContext
    {
        public HealthInsuranceContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HospitalAgent> HospitalAgents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Scheme> Schemes { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<Renewal> Renewals { get ; set; }
        public DbSet<Hospital> Hosiptals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            using (var hmac = new HMACSHA512())
            {
                // Seed Users
                var user1Salt = hmac.Key;
                var user2Salt = hmac.Key;
                var user3Salt = hmac.Key;

                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Uid = 101,
                        FirstName = "Customer",
                        LastName = "Test",
                        Email = "customer1@gmail.com",
                        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test@1234")),
                        Salt = user1Salt,
                        Role = RoleEnum.Customer,
                        Address = "St Street opp lalbagh, chennai , TamilNadu",
                        Zipcode = "507001",
                        MobileNumber = "9999999991",
                        CreatedAt = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new User
                    {
                        Uid = 102,
                        FirstName = "Agent",
                        LastName = "Test",
                        Email = "agent@gmail.com",
                        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test@1234")),
                        Salt = user2Salt,
                        Role = RoleEnum.Agent,
                        Address = "St Street opp lalbagh, chennai , TamilNadu",
                        Zipcode = "507002",
                        MobileNumber = "9999999999",
                        CreatedAt = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new User
                    {
                        Uid = 103,
                        FirstName = "Admin",
                        LastName = "Test",
                        Email = "admin@gmail.com",
                        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test@1234")),
                        Salt = user3Salt,
                        Role = RoleEnum.Admin,
                        Address = "St Street opp lalbagh, chennai , TamilNadu",
                        Zipcode = "507003",
                        MobileNumber = "111111111",
                        CreatedAt = DateTime.Now,
                        LastUpdated = DateTime.Now
                    }
                );;

                // Seed Admins
                modelBuilder.Entity<Admin>().HasData(
                    new Admin { AdminId = 1, Uid = 103 }
                );

                // Seed Customers
                modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        CustomerId = 10001,
                        Uid = 101,
                        DateOfBirth = new DateTime(1990, 1, 1),
                        Gender = GenderEnum.Male,
                        EmergenceyContact = "888888888"
                    }
                );

                // Seed Policies
                modelBuilder.Entity<Policy>().HasData(
                    new Policy
                    {
                        PolicyId = 1,
                        CustomerId = 10001,
                        SchemeId = 1,
                        PolicyStartDate = DateTime.Now,
                        PolicyEndDate = DateTime.Now.AddYears(1),
                        PremiumAmount = 500.0f,
                        PaymentFrequency = PaymentFrequencyEnum.Quarterly,
                        QuoteAmount = 1000.0f,
                        LastPaymentDate = DateTime.Now,
                        NextPaymentDueDate = DateTime.Now.AddMonths(12),
                        PolicyExpiryDate = DateTime.Now.AddYears(1),
                        RenewalStatus = RenewalStatusEnum.Renwed
                    }
                );

                // Seed Schemes
                modelBuilder.Entity<Scheme>().HasData(
                        //Individual
                        new Scheme
                        {
                            SchemeId = 1,
                            SchemeName = "Individual Basic Plan",
                            SchemeDescription = "The Individual Basic Plan offers essential health coverage for individuals at an affordable premium. This plan includes coverage for hospitalization, surgery, and emergency care. It is designed for those seeking fundamental protection against medical expenses.",
                            CoverageAmount = 500000,
                            SchemeType = SchemeTypeEnum.Individual,
                            BasePremiumAmount = 5000,
                            SchemeStartedAt = new DateTime(2020, 1, 1),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 5,
                            CoverageYears = 10,
                            RouteTitle = "individual-basic-plan",
                            BaseCoverageAmount = 100000,
                            SmallDescription = "A Plan For Every Individual Which Covers Basic Need"
                        },
                        new Scheme
                        {
                            SchemeId = 2,
                            SchemeName = "Individual Premium Plan",
                            SchemeDescription = "The Individual Premium Plan provides extensive health coverage for individuals, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for those who want a higher level of health security and comprehensive medical benefits.",
                            CoverageAmount = 1000000,
                            SchemeType = SchemeTypeEnum.Individual,
                            BasePremiumAmount = 10000,
                            SchemeStartedAt = new DateTime(2021, 6, 15),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 7,
                            CoverageYears = 15,
                            RouteTitle = "individual-premium-plan",
                            BaseCoverageAmount = 250000,
                            SmallDescription = "A Plan For Every Person Which Covers the Needs"
                        },
                        new Scheme
                        {
                            SchemeId = 3,
                            SchemeName = "Individual Elite Plan",
                            SchemeDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda voluptatem totam similique nobis dolore in, velit consectetur perspiciatis vero quas. Esse deleniti commodi perferendis officia saepe natus, quas dolor. Perspiciatis iusto nam optio quo natus amet velit explicabo quod, officia adipisci quia ipsum odio deleniti, fugiat esse illum tenetur obcaecati corporis quasi quibusdam dolorum laboriosam in. Numquam autem temporibus molestiae delectus sequi cupiditate suscipit natus facere enim dolorum sed eaque voluptas repellendus officiis et doloremque totam pariatur, quae, non amet explicabo. Maxime, magni! Ea voluptate aspernatur impedit vitae quasi necessitatibus. Ex, commodi quaerat. Dolor deleniti eos amet non. Optio minima quos incidunt recusandae eveniet, consequuntur earum quam nesciunt tenetur deserunt voluptas tempora ipsa omnis ipsam a iusto rerum, obcaecati aut nulla quo, blanditiis perferendis? Quam quo alias error possimus impedit sapiente commodi earum quaerat? Quas natus rem voluptate, at nostrum ut itaque voluptatibus porro velit labore consequatur obcaecati et nulla nihil cum, provident ratione iusto esse iure! Porro, totam cumque molestias officia minus vel molestiae, quod alias excepturi pariatur voluptates quae, cupiditate voluptatem fugit delectus. Ipsa temporibus similique odit veniam quo, cupiditate nesciunt dignissimos consequuntur aperiam, eveniet facilis recusandae voluptates nulla quaerat mollitia labore quae! Sapiente odio deserunt eum suscipit.",
                            CoverageAmount = 2000000,
                            SchemeType = SchemeTypeEnum.Individual,
                            BasePremiumAmount = 20000,
                            SchemeStartedAt = new DateTime(2022, 3, 10),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 10,
                            CoverageYears = 20,
                            RouteTitle = "individual-elite-plan",
                            BaseCoverageAmount = 500000,
                            SmallDescription = "A Plan for Every Individual for every need"
                        },
                        // Corporate Schemes
                        new Scheme
                        {
                            SchemeId = 4,
                            SchemeName = "Corporate Standard Plan",
                            SchemeDescription = "The Corporate Standard Plan offers essential health coverage for employees of small and medium-sized businesses. It includes hospitalization and emergency care benefits, providing basic protection to ensure the well-being of your workforce.",
                            CoverageAmount = 1000000,
                            SchemeType = SchemeTypeEnum.Corporate,
                            BasePremiumAmount = 15000,
                            SchemeStartedAt = new DateTime(2019, 5, 20),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 5,
                            CoverageYears = 10,
                            RouteTitle = "corporate-standard-plan",
                            BaseCoverageAmount = 200000,
                            SmallDescription = "A Plan For Every Corporate Standard Covers basic need"
                        },
                        new Scheme
                        {
                            SchemeId = 5,
                            SchemeName = "Corporate Comprehensive Plan",
                            SchemeDescription = "The Corporate Comprehensive Plan provides extensive health coverage for employees, including benefits for outpatient treatments, preventive care, and specialist consultations. This plan is designed for businesses that want to offer their employees a higher level of health security and comprehensive medical benefits.",
                            CoverageAmount = 2500000,
                            SchemeType = SchemeTypeEnum.Corporate,
                            BasePremiumAmount = 30000,
                            SchemeStartedAt = new DateTime(2020, 8, 25),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 7,
                            CoverageYears = 15,
                            RouteTitle = "corporate-comprehensive-plan",
                            BaseCoverageAmount = 500000,
                            SmallDescription = "A Huge Amount Coverage For  Corporate with Higer number Of Employeess "
                        },
                        new Scheme
                        {
                            SchemeId = 6,
                            SchemeName = "Corporate Premium Plan",
                            SchemeDescription = "The Corporate Premium Plan offers the highest level of health coverage for corporate employees, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for businesses that seek to provide the ultimate health protection and peace of mind for their employees.",
                            CoverageAmount = 5000000,
                            SchemeType = SchemeTypeEnum.Corporate,
                            BasePremiumAmount = 50000,
                            SchemeStartedAt = new DateTime(2021, 11, 30),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 10,
                            CoverageYears = 20,
                            RouteTitle = "corporate-premium-plan",
                            BaseCoverageAmount = 1000000,
                            SmallDescription = "Best Corporate Plan , with Highest Claim Sucess Rate"
                        },
                        // Family Schemes
                        new Scheme
                        {
                            SchemeId = 7,
                            SchemeName = "Family Basic Plan",
                            SchemeDescription = "The Family Basic Plan offers essential health coverage for families, including hospitalization and emergency care benefits. This plan is designed to provide fundamental protection for your family’s health needs at an affordable premium.",
                            CoverageAmount = 1000000,
                            SchemeType = SchemeTypeEnum.Family,
                            BasePremiumAmount = 20000,
                            SchemeStartedAt = new DateTime(2018, 2, 14),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 5,
                            CoverageYears = 10,
                            RouteTitle = "family-basic-plan",
                            BaseCoverageAmount = 200000,
                            SmallDescription = "The best plan with lowest Rate"
                        },
                        new Scheme
                        {
                            SchemeId = 8,
                            SchemeName = "Family Comprehensive Plan",
                            SchemeDescription = "The Family Comprehensive Plan provides extensive health coverage for families, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for families seeking a higher level of health security and comprehensive medical benefits.",
                            CoverageAmount = 3000000,
                            SchemeType = SchemeTypeEnum.Family,
                            BasePremiumAmount = 40000,
                            SchemeStartedAt = new DateTime(2019, 7, 19),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 7,
                            CoverageYears = 15,
                            RouteTitle = "family-comprehensive-plan",
                            BaseCoverageAmount = 600000,
                            SmallDescription = "Huge Amount Coverage which solves most of the needs"
                        },
                        new Scheme
                        {
                            SchemeId = 9,
                            SchemeName = "Family Elite Plan",
                            SchemeDescription = "The Family Elite Plan offers the highest level of health coverage for families, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for families that seek the ultimate health protection and peace of mind.",
                            CoverageAmount = 6000000,
                            SchemeType = SchemeTypeEnum.Family,
                            BasePremiumAmount = 60000,
                            SchemeStartedAt = new DateTime(2020, 10, 25),
                            SchemeLastUpdatedAt = DateTime.Now,
                            PaymentTerm = 10,
                            CoverageYears = 20,
                            RouteTitle = "family-elite-plan",
                            BaseCoverageAmount = 1200000,
                            SmallDescription= "The best Plan To Take Care of your family from every danger"
                        }
                        );

                // Seed Claims
                modelBuilder.Entity<Claims>().HasData(
                    new Claims
                    {
                        ClaimId = 1,
                        PolicyId = 1,
                        CustomerId = 10001,
                        HospitalAgentId = 11111,
                        AmountClaimed = 2000.0f,
                        AmountApproved = 1500.0f,
                        ApprovedBy = 1,
                        ClaimStatus = ClaimStatusEnum.Approved
                    }
                );
                modelBuilder.Entity<Hospital>().HasData(
                 new Hospital { Id = 1 , BranchCode = "Kmm05" , City = "Khammam" , Name = "Hosiptal A" , State = "Telangana" , Street = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." , Zipcode = 507001 }
               );


                // Seed HospitalAgents
                modelBuilder.Entity<HospitalAgent>().HasData(
                    new HospitalAgent
                    {
                        AgentId = 11111, HosiptalId = 1, Uid = 102 , AgentContact = "7000001111" , 
                    }
                );

                // Seed Payments
                modelBuilder.Entity<Payment>().HasData(
                    new Payment
                    {
                        Id = 10001,
                        TransactionId = 100001,
                        PolicyId = 1,
                        CustomerId = 10001,
                        PaymentDate = DateTime.Now,
                        PaymentStatus = "Completed",
                        Remarks = "First payment of the year",
                        PaymentAmount = 500.0f
                    }
                );

                // Seed Renewals
                modelBuilder.Entity<Renewal>().HasData(
                    new Renewal
                    {
                        RenewalId = 1,
                        PolicyId = 1,
                        CustomerId = 10001,
                        RenewalDate = DateTime.Now,
                        NewPolicyStartDate = DateTime.Now.AddYears(1),
                        NewPremiumAmount = 550.0f,
                        NewPaymentFrequency = PaymentFrequencyEnum.Anually,
                        DiscountApplied = 0f,
                        RenewalStatus = RenewalStatusEnum.Pending
                    },
                    new Renewal
                    {
                        RenewalId = 2,
                        PolicyId = 1,
                        CustomerId = 10001,
                        RenewalDate = DateTime.Now.AddYears(1),
                        NewPolicyStartDate = DateTime.Now.AddYears(2),
                        NewPremiumAmount = 800.0f,
                        NewPaymentFrequency = PaymentFrequencyEnum.Quarterly,
                        DiscountApplied = 100.0f,
                        RenewalStatus = RenewalStatusEnum.Renwed
                    }
                );
            }


            modelBuilder.Entity<Claims>()
         .Property(c => c.ClaimStatus)
         .HasConversion(new EnumToStringConverter<ClaimStatusEnum>());

            modelBuilder.Entity<Customer>()
                .Property(c => c.Gender)
                .HasConversion(new EnumToStringConverter<GenderEnum>());

            modelBuilder.Entity<Policy>()
                .Property(p => p.PaymentFrequency)
                .HasConversion(new EnumToStringConverter<PaymentFrequencyEnum>());

            modelBuilder.Entity<Policy>()
                .Property(p => p.RenewalStatus)
                .HasConversion(new EnumToStringConverter<RenewalStatusEnum>());

            modelBuilder.Entity<Renewal>()
                .Property(r => r.NewPaymentFrequency)
                .HasConversion(new EnumToStringConverter<PaymentFrequencyEnum>());

            modelBuilder.Entity<Renewal>()
                .Property(r => r.RenewalStatus)
                .HasConversion(new EnumToStringConverter<RenewalStatusEnum>());

            modelBuilder.Entity<Scheme>()
                .Property(s => s.SchemeType)
                .HasConversion(new EnumToStringConverter<SchemeTypeEnum>());

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(new EnumToStringConverter<RoleEnum>());
            modelBuilder.Entity<Customer>()
                 .HasOne(c => c.User)
                 .WithOne()
                 .HasForeignKey<Customer>(c => c.Uid)
                 .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Admin>()
                 .HasOne(a => a.User)
                 .WithOne()
                 .HasForeignKey<Admin>(a => a.Uid)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HospitalAgent>()
                 .HasOne(ha => ha.User)
                 .WithOne()
                 .HasForeignKey<HospitalAgent>(ha => ha.Uid)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Policy>()
                .HasOne(p => p.Scheme)
                .WithOne()
                .HasForeignKey<Policy>(p => p.SchemeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Renewal>()
             .HasOne(r => r.Policy)
             .WithMany(p => p.Renewals)
             .HasForeignKey(r => r.PolicyId )
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Policy>()
              .HasOne(p => p.Customer)
              .WithMany(c => c.Policies)
              .HasForeignKey(ci => ci.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Payment>()
              .HasOne(p => p.Policy)
              .WithMany(po => po.Payments)
              .HasForeignKey(p => p.PolicyId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
              .HasOne(p => p.Customer)
              .WithMany(c => c.Payments)
              .HasForeignKey(p => p.CustomerId)
              .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Renewal>()
              .HasOne(r => r.Customer)
              .WithMany(c => c.Renewals)
              .HasForeignKey(p => p.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HospitalAgent>()
            .HasOne(ha => ha.Hosiptal)
            .WithMany(h => h.Agents)
            .HasForeignKey( h => h.HosiptalId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
