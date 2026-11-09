using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationDetection.Services
{
    public class VideoService
    {
        public bool IsRunning { get; private set; }

        public string? CurrentSource { get; private set; }

        public Task StartAsync(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException(
                    "Video source cannot be empty.",
                    nameof(source));
            }

            CurrentSource = source;
            IsRunning = true;

            // Sau này xử lý camera/video ở đây.
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            IsRunning = false;
            CurrentSource = null;

            return Task.CompletedTask;
        }
    }
}