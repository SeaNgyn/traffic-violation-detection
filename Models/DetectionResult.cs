using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationDetection.Models
{
    public class DetectionResult
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ObjectType { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ViolationType { get; set; }

        public double Confidence { get; set; }

        public double BoundingBoxX { get; set; }

        public double BoundingBoxY { get; set; }

        public double BoundingBoxWidth { get; set; }

        public double BoundingBoxHeight { get; set; }

        public DateTime DetectedAt { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        public int CameraId { get; set; }

        public Camera Camera { get; set; } = null!;

        public bool IsViolation { get; set; }

        public bool IsProcessed { get; set; }
    }
}