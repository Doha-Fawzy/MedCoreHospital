using MedCoreHospital.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ScheduleId { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? CancellationReason { get; set; }
        public bool IsDeleted { get; set; }
        public Patient? Patient { get; set; }
        public DoctorSchedule? Schedule { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
        public DateTime LastModified { get; set; }
        public byte[] Version { get; set; } = Array.Empty<byte>();
    }

}
