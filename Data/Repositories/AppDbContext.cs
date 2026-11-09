using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrafficViolationDetection.Models;

namespace TrafficViolationDetection.Data.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        public DbSet<Camera> Cameras => Set<Camera>();

        public DbSet<Violation> Violations => Set<Violation>();

        public DbSet<DetectionResult> DetectionResults
            => Set<DetectionResult>();

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var connectionString =
                    configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(vehicle => vehicle.LicensePlate);

            modelBuilder.Entity<Violation>()
                .HasOne(violation => violation.Vehicle)
                .WithMany(vehicle => vehicle.Violations)
                .HasForeignKey(violation => violation.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Violation>()
                .HasOne(violation => violation.Camera)
                .WithMany(camera => camera.Violations)
                .HasForeignKey(violation => violation.CameraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetectionResult>()
                .HasOne(result => result.Camera)
                .WithMany(camera => camera.DetectionResults)
                .HasForeignKey(result => result.CameraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Camera>().HasData(
                new Camera
                {
                    Id = 1,
                    Name = "Camera 01",
                    Location = "Main Street",
                    StreamUrl = "camera-01",
                    IsActive = true
                },
                new Camera
                {
                    Id = 2,
                    Name = "Camera 02",
                    Location = "City Intersection",
                    StreamUrl = "camera-02",
                    IsActive = true
                });
        }
    }
}