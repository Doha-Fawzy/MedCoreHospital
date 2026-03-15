using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Doctor : User
    {
        public int SpecialtyId { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal HourRate { get; set; }
        public Specialty? Specialty { get; set; }
        public ICollection<DoctorSchedule>? Schedules { get; set; }
    }

}
