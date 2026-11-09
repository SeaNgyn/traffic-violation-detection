using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationDetection.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string? LicensePlate { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehicleType { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Color { get; set; }

        [MaxLength(100)]
        public string? OwnerName { get; set; }

        public ICollection<Violation> Violations { get; set; }
            = new List<Violation>();
    }
}