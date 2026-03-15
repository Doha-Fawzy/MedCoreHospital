using MedCoreHospital.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedCoreHospital.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? ProfileImage { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModified { get; set; }
        public byte[]? Version { get; set; }
    }

}
