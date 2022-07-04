namespace API.Resources.DataLogic
{
    using API.Resources.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public sealed class NpsqlContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalPassport> AnimalPassports { get; set; }
        public DbSet<AnimalProcedure> AnimalProcedures { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }

        public NpsqlContext(DbContextOptions<NpsqlContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information);
                //.AddInterceptors(new Interceptor[1]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasKey(app => new
            {
                Date = app.AppointmentDate,
                DoctorPassport = app.DoctorPassport
            });

            modelBuilder.Entity<Owner>()
                .HasIndex(person => person.Phone)
                .IsUnique();

            modelBuilder.Entity<Owner>()
                .HasData(
                new Owner()
                {
                    Birthday = DateTime.Now,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Patronymic = "Иванович",
                    //password: rkrk
                    HashedPassword = @"lTjPsVByCKr5mR4fEiHI4kxPEc/J9EUV0F+i1/6Ds1Y=",
                    Salt = @"FDMZiazOFJBfODgrIhQlEzT1wWc7u41XNJ4iOuP2NLHXx+rqVtEhtVj3qF3c0aZqAHZ9BKnZOWEJGAXTdT0SXQ==",
                    Phone = "+7 (962) 573-61-85",
                    Passport = "9211 237553",
                }
                );

            modelBuilder.Entity<Doctor>()
                .HasIndex(person => person.Phone)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor()
                {
                    FirstName = "Андрей",
                    LastName = "Рихтер",
                    Patronymic = "Александрович",
                    Birthday = new DateTime(1964, 6, 3),
                    Diseases = new List<Disease>(),
                    Passport = "9212 748275",
                    Position = "Заведующий лечебно-диагностическм отделением",
                    Phone = "+7 (962) 915-84-32",
                    Schedule = new List<Appointment>(),
                    MinutesForAppointment = 60
                },
                new Doctor()
                {
                    FirstName = "Владимир",
                    LastName = "Калинин",
                    Patronymic = "Александрович",
                    Birthday = new DateTime(1983, 3, 2),
                    Diseases = new List<Disease>(),
                    Passport = "9212 923285",
                    Position = "Хирург",
                    Phone = "+7 (952) 944-54-44",
                    Schedule = new List<Appointment>(),
                    MinutesForAppointment = 50
                });
        }

    }
}
