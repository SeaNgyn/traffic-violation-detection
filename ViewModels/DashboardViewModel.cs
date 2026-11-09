using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationDetection.Data.Repositories;

namespace TrafficViolationDetection.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private int _totalViolations;
        private int _pendingViolations;
        private int _activeCameras;

        public int TotalViolations
        {
            get => _totalViolations;
            set => SetProperty(ref _totalViolations, value);
        }

        public int PendingViolations
        {
            get => _pendingViolations;
            set => SetProperty(ref _pendingViolations, value);
        }

        public int ActiveCameras
        {
            get => _activeCameras;
            set => SetProperty(ref _activeCameras, value);
        }

        public async Task LoadAsync()
        {
            await using var context = new AppDbContext();

            TotalViolations =
                await context.Violations.CountAsync();

            PendingViolations =
                await context.Violations.CountAsync(
                    violation => violation.Status == "Pending");

            ActiveCameras =
                await context.Cameras.CountAsync(
                    camera => camera.IsActive);
        }
    }
}