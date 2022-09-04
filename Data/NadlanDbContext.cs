using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Data
{
    public partial class NadlanDbContext : IdentityDbContext
    {
        public NadlanDbContext()
        {
        }

        public NadlanDbContext(DbContextOptions<NadlanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<ExperienceLevel> ExperienceLevels { get; set; } = null!;
        public virtual DbSet<House> Houses { get; set; } = null!;
        public virtual DbSet<HouseType> HouseTypes { get; set; } = null!;
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SalesMan> SalesMen { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<VAvailableHouse> VAvailableHouses { get; set; } = null!;
        public virtual DbSet<VCustomers2yearsExpiry> VCustomers2yearsExpiries { get; set; } = null!;
        public virtual DbSet<VExcellentWorker> VExcellentWorkers { get; set; } = null!;
        public virtual DbSet<VNeighborhoodTotalPrice> VNeighborhoodTotalPrices { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cities__CountryI__2B3F6F97");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("Company Name");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Website).HasMaxLength(124);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.CountryName, "UQ__Countrie__E056F2012BF2DF16")
                    .IsUnique();

                entity.HasIndex(e => e.Numeric, "UQ__Countrie__FD07398E49BCA584")
                    .IsUnique();

                entity.Property(e => e.Alpha2Code)
                    .HasMaxLength(2)
                    .HasColumnName("Alpha-2 Code");

                entity.Property(e => e.Alpha3Code)
                    .HasMaxLength(3)
                    .HasColumnName("Alpha-3 Code");

                entity.Property(e => e.CountryName).HasMaxLength(100);

                entity.Property(e => e.Numeric)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExperienceLevel>(entity =>
            {
                entity.HasKey(e => e.Level)
                    .HasName("PK__Experien__AAF89963FD7FB909");

                entity.ToTable("Experience Levels");

                entity.Property(e => e.Level)
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.HouseId).HasColumnName("HouseID");

                entity.Property(e => e.Address).HasMaxLength(35);

                entity.Property(e => e.BuiltAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Built At");

                entity.Property(e => e.ForSale).HasColumnName("For Sale");

                entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.SizeM2).HasColumnName("Size (M^2)");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID")
                    .IsFixedLength();

                entity.Property(e => e.WantedPrice)
                    .HasColumnType("money")
                    .HasColumnName("Wanted Price");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Houses__Neighbor__4CA06362");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Houses__OwnerID__4AB81AF0");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Houses__TypeID__4BAC3F29");
            });

            modelBuilder.Entity<HouseType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__House ty__516F039547DF580F");

                entity.ToTable("House types");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Neighborhoods)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Neighborh__CityI__2E1BDC42");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__People__79578B9397F0A394")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("First Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("Last Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("Phone Number");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__People__CompanyI__35BCFE0A");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.SaleId, "UQ__Sales__1EE3C41EB7AF572C")
                    .IsUnique();

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.FinalPrice)
                    .HasColumnType("money")
                    .HasColumnName("Final Price");

                entity.Property(e => e.HouseId).HasColumnName("HouseID");

                entity.Property(e => e.Income).HasDefaultValueSql("((0.05))");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Publish Date");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Sale date");

                entity.Property(e => e.SalesManId).HasColumnName("SalesManID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.SaleBuyers)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Sales__BuyerID__5165187F");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.HouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__HouseID__5070F446");

                entity.HasOne(d => d.SalesMan)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalesManId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__SalesManI__5441852A");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.SaleSellers)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__SellerID__52593CB8");
            });

            modelBuilder.Entity<SalesMan>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__SalesMen__79578B937FEB9CB2")
                    .IsUnique();

                entity.Property(e => e.SalesManId).HasColumnName("SalesManID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Birth Date");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("First Name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Hire Date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("Last Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("Phone Number");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SalesMen)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesMen__Compan__3A81B327");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => new { e.SalesManId, e.TypeId })
                    .HasName("PK__Speciali__6F0E227E2287D5F7");

                entity.ToTable("Specialization");

                entity.Property(e => e.SalesManId).HasColumnName("SalesManID");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID")
                    .IsFixedLength();

                entity.Property(e => e.Level)
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.HasOne(d => d.LevelNavigation)
                    .WithMany(p => p.Specializations)
                    .HasForeignKey(d => d.Level)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specializ__Level__440B1D61");

                entity.HasOne(d => d.SalesMan)
                    .WithMany(p => p.Specializations)
                    .HasForeignKey(d => d.SalesManId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specializ__Sales__4222D4EF");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Specializations)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specializ__TypeI__4316F928");
            });

            modelBuilder.Entity<VAvailableHouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_AVAILABLE_HOUSES");

                entity.Property(e => e.Address).HasMaxLength(35);

                entity.Property(e => e.BuiltAt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Built At");

                entity.Property(e => e.ForSaleHouseId).HasColumnName("For sale HouseID");

                entity.Property(e => e.HouseOwnerId).HasColumnName("HouseOwnerID");

                entity.Property(e => e.Neighbor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NeighborId).HasColumnName("NeighborID");

                entity.Property(e => e.SameCityId).HasColumnName("SameCityID");

                entity.Property(e => e.SizeM2).HasColumnName("Size (M^2)");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID")
                    .IsFixedLength();

                entity.Property(e => e.WantedPrice)
                    .HasColumnType("money")
                    .HasColumnName("Wanted Price");
            });

            modelBuilder.Entity<VCustomers2yearsExpiry>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_CUSTOMERS_2YEARS_EXPIRY");

                entity.Property(e => e.FullName)
                    .HasMaxLength(61)
                    .HasColumnName("Full Name");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("Phone Number");

                entity.Property(e => e.SaleDate)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Sale Date");
            });

            modelBuilder.Entity<VExcellentWorker>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EXCELLENT_WORKER");

                entity.Property(e => e.SalesManId).HasColumnName("SalesManID");

                entity.Property(e => e.TotalIncome).HasColumnName("Total Income");
            });

            modelBuilder.Entity<VNeighborhoodTotalPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Neighborhood_TOTAL_Price");

                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TotalWanted)
                    .HasColumnType("money")
                    .HasColumnName("Total Wanted");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(role => new { role.RoleId, role.UserId });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(c => c.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => t.UserId);
            modelBuilder.Entity<IdentityUser<string>>().HasKey(u => u.Id);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
