using MedCoreHospital.Enums;
using MedCoreHospital.OwnedTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Patient : User
    {
        public BloodType BloodType { get; set; }
        public Allergies Allergies { get; set; }
        public ChronicConditions ChronicConditions { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

}
