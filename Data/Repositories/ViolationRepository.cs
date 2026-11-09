using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationDetection.Models;

namespace TrafficViolationDetection.Data.Repositories
{
    public class ViolationRepository
    {
        public async Task<List<Violation>> GetAllAsync()
        {
            await using var context = new AppDbContext();

            return await context.Violations
                .Include(violation => violation.Vehicle)
                .Include(violation => violation.Camera)
                .OrderByDescending(violation => violation.DetectedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Violation?> GetByIdAsync(int id)
        {
            await using var context = new AppDbContext();

            return await context.Violations
                .Include(violation => violation.Vehicle)
                .Include(violation => violation.Camera)
                .AsNoTracking()
                .FirstOrDefaultAsync(violation => violation.Id == id);
        }

        public async Task AddAsync(Violation violation)
        {
            await using var context = new AppDbContext();

            context.Violations.Add(violation);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Violation violation)
        {
            await using var context = new AppDbContext();

            context.Violations.Update(violation);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = new AppDbContext();

            var violation = await context.Violations.FindAsync(id);

            if (violation == null)
            {
                return;
            }

            context.Violations.Remove(violation);
            await context.SaveChangesAsync();
        }
    }
}