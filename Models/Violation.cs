using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrafficViolationDetection.Models
{
    public class Violation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ViolationType { get; set; } = string.Empty;

        public DateTime DetectedAt { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        [MaxLength(500)]
        public string? VideoPath { get; set; }

        public double Confidence { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        [MaxLength(1000)]
        public string? Description { get; set; }

        public int? VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public int CameraId { get; set; }

        public Camera Camera { get; set; } = null!;
    }

    //    ViolationType: Không đội mũ bảo hiểm
    //DetectedAt: 02/11/2026 14:30
    //Confidence: 0.95
    //Status: Pending
    //ImagePath: Evidence/violation-001.jpg
}