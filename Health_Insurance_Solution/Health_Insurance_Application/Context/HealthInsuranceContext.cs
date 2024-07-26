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
                        Street = "Test Lorem , blaaa",
                        City = "Springfield",
                        State = "IL",
                        Zipcode = "507001",
                        MobileNumber = "7673978319",
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
                        Street = "Test lorem , fam",
                        City = "Springfield",
                        State = "IL",
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
                        Street = "789 Oak St",
                        City = "Springfield",
                        State = "IL",
                        Zipcode = "507003",
                        MobileNumber = "111111111",
                        CreatedAt = DateTime.Now,
                        LastUpdated = DateTime.Now
                    }
                );

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
                    new Scheme
                    {
                        SchemeId = 1,
                        SchemeName = "Basic Health Plan",
                        SchemeDescription = "Provides basic health coverage.",
                        CoverageAmount = 10000.0f,
                        SchemeType = SchemeTypeEnum.Individual,
                        BasePremiumAmount = 500.0f
                    },
                    new Scheme
                    {
                        SchemeId = 2,
                        SchemeName = "Family Health Plan",
                        SchemeDescription = "Provides health coverage for families.",
                        CoverageAmount = 25000.0f,
                        SchemeType = SchemeTypeEnum.Family,
                        BasePremiumAmount = 750.0f
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
                        TransactionId = 1,
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
