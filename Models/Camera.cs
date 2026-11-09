using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationDetection.Models
{
    public class Camera
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? StreamUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Violation> Violations { get; set; }
            = new List<Violation>();

        public ICollection<DetectionResult> DetectionResults { get; set; }
            = new List<DetectionResult>();
    }
}