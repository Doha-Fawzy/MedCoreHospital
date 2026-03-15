using MedCoreHospital.Data;
using MedCoreHospital.Enums;
using Microsoft.EntityFrameworkCore;


namespace MedCoreHospital.Queries
{
    public static class CancelledTransaction
    {
        public static void CancelAppointment(HospitalDbContext context, int appointmentId)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var appointment = context.Appointments
                                         .Include(a => a.Schedule)
                                         .First(a => a.Id == appointmentId);

                appointment.Status = AppointmentStatus.Cancelled;

                appointment?.Schedule?.IsBooked = false;

                context.SaveChanges();

                transaction.Commit();
                Console.WriteLine("Appointment Cancelled Successfully");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e);
            }
        }
    }
}
