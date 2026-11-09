using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationDetection.Data.Repositories;
using TrafficViolationDetection.Models;

namespace TrafficViolationDetection.Services
{
    public class DetectionService
    {
        public async Task<DetectionResult> DetectFromImageAsync(
            string imagePath,
            int cameraId)
        {
            // Tạm thời dùng dữ liệu giả để kiểm tra database.
            // Sau này thay bằng YOLO/ONNX hoặc gọi Python API.

            var result = new DetectionResult
            {
                ObjectType = "Motorcycle",
                ViolationType = "No Helmet",
                Confidence = 0.95,
                BoundingBoxX = 100,
                BoundingBoxY = 80,
                BoundingBoxWidth = 300,
                BoundingBoxHeight = 250,
                DetectedAt = DateTime.Now,
                ImagePath = imagePath,
                CameraId = cameraId,
                IsViolation = true,
                IsProcessed = false
            };

            await using var context = new AppDbContext();

            context.DetectionResults.Add(result);
            await context.SaveChangesAsync();

            return result;
        }

        public async Task<Violation?> CreateViolationAsync(
            DetectionResult detectionResult,
            int? vehicleId = null)
        {
            if (!detectionResult.IsViolation)
            {
                return null;
            }

            var violation = new Violation
            {
                ViolationType =
                    detectionResult.ViolationType ?? "Unknown",
                DetectedAt = detectionResult.DetectedAt,
                ImagePath = detectionResult.ImagePath,
                Confidence = detectionResult.Confidence,
                Status = "Pending",
                Description =
                    $"Detected object: {detectionResult.ObjectType}",
                CameraId = detectionResult.CameraId,
                VehicleId = vehicleId
            };

            await using var context = new AppDbContext();

            context.Violations.Add(violation);

            var savedDetectionResult =
                await context.DetectionResults.FindAsync(
                    detectionResult.Id);

            if (savedDetectionResult != null)
            {
                savedDetectionResult.IsProcessed = true;
            }

            await context.SaveChangesAsync();

            return violation;
        }
    }
}