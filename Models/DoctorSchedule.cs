using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class DoctorSchedule
    {
        public int? Id { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsDeleted { get; set; }
        public Doctor? Doctor { get; set; }
        public Appointment? Appointment { get; set; }
        public DateTime? LastModified { get; set; }
        public byte[] Version { get; set; }
    }

}
