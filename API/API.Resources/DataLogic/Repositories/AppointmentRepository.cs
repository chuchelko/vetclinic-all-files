namespace API.Resources.DataLogic.Repositories
{
    using System.Threading.Tasks;

    using API.Resources.Entities;

    using Microsoft.EntityFrameworkCore;

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly NpsqlContext context;

        public AppointmentRepository(NpsqlContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateAsync(Appointment appointment)
        {

            var foundEntity = await context.Set<Appointment>()
                .FirstOrDefaultAsync(app => 
                    app.AppointmentDate == appointment.AppointmentDate 
                    && app.DoctorPassport == appointment.DoctorPassport);

            if (foundEntity == null)
                return false;

            if (foundEntity.OwnerPassport != null)
                return false;

            foundEntity.OwnerPassport = appointment.OwnerPassport;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string doctorPhone, DateTime date) 
        {
            var doctor = await context.Set<Doctor>().FirstAsync(doc => doc.Phone == doctorPhone);

            var key = new
            {
                Date = date,
                DoctorPassport = doctor.Passport
            };

            var foundEntity = await context.Set<Appointment>().FindAsync(key);

            if (foundEntity == null)
                return false;

            context.Set<Appointment>().Remove(foundEntity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Appointment>> GetAsync(Owner owner)
        {
            return await context.Set<Appointment>()
                .Where(app => app.Owner.Passport == owner.Passport)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetDoctorWeekAppointments(Doctor doctor)
        {
            DateTime startOfThatDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return await context.Set<Appointment>()
                .Include(app => app.Owner)
                .Where(appointment => 
                appointment.DoctorPassport == doctor.Passport
                && appointment.AppointmentDate >= startOfThatDay
                && appointment.AppointmentDate <= startOfThatDay.AddDays(7))
                .ToListAsync();
        }

        public async Task<bool> SaveAsync(Appointment appointment) 
        {
            await context.SaveChangesAsync();
            return true;
        }
    }
}
