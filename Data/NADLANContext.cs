using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReverseEnginereeing.Models;
using ReverseEnginereeing.Models.Generated.Views;

namespace ReverseEnginereeing.Data
{
    public partial class NADLANContext : DbContext
    {
        public NADLANContext()
        {
        }

        public NADLANContext(DbContextOptions<NADLANContext> options)
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
                entity.Property(e => e.CityName).IsFixedLength();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cities__CountryI__2B3F6F97");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Numeric).IsFixedLength();
            });

            modelBuilder.Entity<ExperienceLevel>(entity =>
            {
                entity.HasKey(e => e.Level)
                    .HasName("PK__Experien__AAF899630983E740");

                entity.Property(e => e.Level).IsFixedLength();
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.TypeId).IsFixedLength();

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
                    .HasName("PK__House ty__516F0395EF75E4DB");

                entity.Property(e => e.TypeId).IsFixedLength();
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Neighborhoods)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Neighborh__CityI__2E1BDC42");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__People__CompanyI__35BCFE0A");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Income).HasDefaultValueSql("((0.05))");

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
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SalesMen)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesMen__Compan__3A81B327");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => new { e.SalesManId, e.TypeId })
                    .HasName("PK__Speciali__6F0E227E4CD88706");

                entity.Property(e => e.TypeId).IsFixedLength();

                entity.Property(e => e.Level).IsFixedLength();

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
                entity.ToView("V_AVAILABLE_HOUSES");

                entity.Property(e => e.Neighbor).IsFixedLength();

                entity.Property(e => e.TypeId).IsFixedLength();
            });

            modelBuilder.Entity<VCustomers2yearsExpiry>(entity =>
            {
                entity.ToView("V_CUSTOMERS_2YEARS_EXPIRY");
            });

            modelBuilder.Entity<VExcellentWorker>(entity =>
            {
                entity.ToView("V_EXCELLENT_WORKER");
            });

            modelBuilder.Entity<VNeighborhoodTotalPrice>(entity =>
            {
                entity.ToView("V_Neighborhood_TOTAL_Price");

                entity.Property(e => e.CityName).IsFixedLength();

                entity.Property(e => e.Neighborhood).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
