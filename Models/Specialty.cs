using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Image { get; set; }
        public string? Description { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
    }

}
