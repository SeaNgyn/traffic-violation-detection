using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationDetection.Models;

namespace TrafficViolationDetection.Data.Repositories
{
    public class VehicleRepository
    {
        public async Task<List<Vehicle>> GetAllAsync()
        {
            await using var context = new AppDbContext();

            return await context.Vehicles
                .OrderBy(vehicle => vehicle.LicensePlate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Vehicle?> GetByLicensePlateAsync(
            string licensePlate)
        {
            await using var context = new AppDbContext();

            return await context.Vehicles
                .FirstOrDefaultAsync(
                    vehicle => vehicle.LicensePlate == licensePlate);
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            await using var context = new AppDbContext();

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            return vehicle;
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            await using var context = new AppDbContext();

            context.Vehicles.Update(vehicle);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = new AppDbContext();

            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return;
            }

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
        }
    }
}