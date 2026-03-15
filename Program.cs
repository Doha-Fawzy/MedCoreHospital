using MedCoreHospital.Data;
using MedCoreHospital.Models;
using MedCoreHospital.Queries;
using Microsoft.EntityFrameworkCore;

var context = new HospitalDbContext();
var schedule = SearchDoctorScedule.GetScheduleById(context, 1);
Console.WriteLine(schedule?.Doctor?.FullName);
Console.WriteLine( );
//using AsNoTracking
var appointments = context.Appointments
                          .AsNoTracking()
                          .Include(a => a.Patient)
                          .Include(a => a.Schedule)
                          .ToList();
foreach(var a in appointments)
{
    Console.WriteLine($"Appointment ID: {a.Id}");
    Console.WriteLine($"Patient: {a.Patient?.FullName}");
    Console.WriteLine($"Start Scedule: {a.Schedule?.StartTime}");
    Console.WriteLine($"End Scedule: {a.Schedule?.EndTime}");
    Console.WriteLine($"Status: {a.Status}");
}

//testc Canceeled Appointment
Console.WriteLine();
CancelledTransaction.CancelAppointment(context, 1);
