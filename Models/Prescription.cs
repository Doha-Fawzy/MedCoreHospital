using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Prescription
    {
        public int? AppointmentId { get; set; }
        public int? MedicationId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public Appointment? Appointment { get; set; }
        public DateTime? LastModified { get; set; }
        public Medication? Medication { get; set; }
    }

}
