namespace API.Resources.DataLogic.Repositories
{
    using System;
    using System.Threading.Tasks;

    using API.Resources.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class CoreRepository
    {
        private NpsqlContext context;

        private ILogger<CoreRepository> logger;

        public IEntityRepository<Animal, string> Animals { get; set; }

        public IEntityRepository<AnimalPassport, string> AnimalPassports { get; }

        public IEntityRepository<AnimalProcedure, int> AnimalProcedures { get; }

        public IAppointmentRepository Appointments { get; }

        public IEntityRepository<Disease, int> Diseases { get; }

        public IEntityRepository<Doctor, string> Doctors { get; }

        public IEntityRepository<Owner, string> Owners { get; }

        public IEntityRepository<ProvidedService, int> ProvidedServices { get; }

        public CoreRepository(NpsqlContext _context, IEntityRepository<Animal, string> animals, IEntityRepository<AnimalPassport, string> animalPassports
            , IEntityRepository<AnimalProcedure, int> animalProcedures, IAppointmentRepository appointments
            , IEntityRepository<Disease, int> diseases, IEntityRepository<Doctor, string> doctors
            , IEntityRepository<Owner, string> owners, IEntityRepository<ProvidedService, int> providedServices
            , ILogger<CoreRepository> _logger)

        {
            context = _context;
            Animals = animals;
            AnimalPassports = animalPassports;
            AnimalProcedures = animalProcedures;
            Appointments = appointments;
            Diseases = diseases;
            Doctors = doctors;
            Owners = owners;
            ProvidedServices = providedServices;
            logger = _logger;

            var _doctors = GetAllDoctors();
            if(context.Set<Appointment>().ToList().Count == 0)
            {
                foreach (var doctor in _doctors)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        TimeSpan currentTime = new TimeSpan(8, 0, 0);
                        while (currentTime.Hours < 14)
                        {
                            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            logger.LogInformation(now.AddDays(i).Add(currentTime) + " " + doctor.LastName, null);
                            context.Set<Appointment>().Add(new Appointment()
                            {
                                AppointmentDate = now.AddDays(i).Add(currentTime),
                                Doctor = doctor,
                                Owner = null
                            });
                            currentTime += TimeSpan.FromMinutes(doctor.MinutesForAppointment);
                        }
                    }
                }
            }
            context.SaveChanges();
        }

        private List<Doctor> GetAllDoctors()
        {
            return context.Set<Doctor>()
                 .ToList();
        }

        public async Task<Doctor?> GetDoctorByPhoneAsync(string doctorPhone)
        {
            return await context.Set<Doctor>()
                .FirstOrDefaultAsync(doctor => doctor.Phone == doctorPhone);
        }

        public async Task<Owner?> GetOwnerByPhoneAsync(string ownerPhone)
        {
            return await context.Set<Owner>()
                .FirstOrDefaultAsync(owner => owner.Phone == ownerPhone);
        }

        public async Task<Owner?> GetOwnerByPhoneWithServicesAsync(string ownerPhone)
        {
            return await context.Set<Owner>()
                .Include(o => o.Services)
                .FirstOrDefaultAsync(owner => owner.Phone == ownerPhone);
        }

        public async Task<IEnumerable<Animal>> GetOwnerAnimalsAsync(Owner owner)
        {
            return await context.Set<Animal>()
                .Where(animal => animal.OwnerPassport == owner.Key)
                .ToListAsync();
        }

        public async Task<IEnumerable<Disease>?> GetDiseasesAsync(Animal animal)
        {
            var animalWithDiseases = await context.Set<Animal>()
                .Include(a => a.Diseases)
                .FirstOrDefaultAsync(a => a.AnimalPassportChipNumber == animal.AnimalPassportChipNumber);

            return animalWithDiseases?.Diseases;
        }

        public List<Owner> GetOwners()
        {
            return context.Set<Owner>().ToList();
        }
    }
}
