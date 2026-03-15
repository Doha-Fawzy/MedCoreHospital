using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? GenericName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime LastModified { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
    }

}
