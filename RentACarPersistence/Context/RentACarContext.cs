using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities;
using RentACarDomain.Entities;

namespace RentACarPersistence.Context;

public class RentACarContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-2K9PCLA; initial Catalog=RentACarDb; integrated Security = true; TrustServerCertificate=true");

    }
    public DbSet<RentaCar> RentACars { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
        .HasOne(x => x.PickUpLocation)
        .WithMany(y => y.PickUpReservation)
        .HasForeignKey(z => z.PickUpLocationID)
        .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Reservation>()
            .HasOne(x => x.DropOffLocation)
            .WithMany(y => y.DropOffReservation)
            .HasForeignKey(z => z.DropOffLocationID)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }

}
