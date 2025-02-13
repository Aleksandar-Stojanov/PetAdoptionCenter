using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;
using System;
using System.Collections.Generic;


namespace PetAdoptionCenter.Repository;

public partial class TravelAgencyDbContext : DbContext
{
    public TravelAgencyDbContext()
    {
    }

    public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accommodation> Accommodations { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }


    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Itinerary> Itineraries { get; set; }

    public virtual DbSet<TravelPackage> TravelPackages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=travel-agency-server.database.windows.net;Database=Travel-Agency-Database;User Id=mar-ari;Password=dotNet123!;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PricePerNight).HasColumnType("decimal(18, 2)");
        });




        modelBuilder.Entity<AspNetUser>(entity =>
        {

            entity.Property(e => e.Email).HasMaxLength(256);

        });



        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasIndex(e => e.TravelPackageId, "IX_Bookings_TravelPackageId");

            entity.HasIndex(e => e.UserId, "IX_Bookings_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TravelPackage).WithMany(p => p.Bookings).HasForeignKey(d => d.TravelPackageId);

            entity.HasOne(d => d.User).WithMany(p => p.Bookings).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Itinerary>(entity =>
        {
            entity.HasIndex(e => e.TravelPackageId, "IX_Itineraries_TravelPackageId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.TravelPackage).WithMany(p => p.Itineraries).HasForeignKey(d => d.TravelPackageId);
        });

        modelBuilder.Entity<TravelPackage>(entity =>
        {
            entity.HasIndex(e => e.AccommodationId, "IX_TravelPackages_AccommodationId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Accommodation).WithMany(p => p.TravelPackages).HasForeignKey(d => d.AccommodationId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
