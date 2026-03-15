using MedCoreHospital.Data;
using MedCoreHospital.Models;

var context = new HospitalDbContext();

var specialty = new Specialty
{
    Name = "Cardiology",
    Description = "Heart Specialist"
};

context.Specialties.Add(specialty);
context.SaveChanges();

Console.WriteLine("Specialty Added");
