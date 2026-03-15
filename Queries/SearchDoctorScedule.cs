using MedCoreHospital.Data;
using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MedCoreHospital.Queries
{
    public static class SearchDoctorScedule
    {
        public static readonly Func<HospitalDbContext, int, DoctorSchedule?> GetScheduleById =
            EF.CompileQuery((HospitalDbContext context, int id) =>
                context.Schedules
                       .Include(s => s.Doctor)
                       .FirstOrDefault(s => s.Id == id)
            );
    }
}
