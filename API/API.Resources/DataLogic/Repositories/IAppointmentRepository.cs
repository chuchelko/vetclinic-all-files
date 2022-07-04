namespace API.Resources.DataLogic.Repositories
{
    using System;

    using API.Resources.Entities;

    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAsync(Owner owner);

        Task<List<Appointment>> GetDoctorWeekAppointments(Doctor doctor);

        Task<bool> CreateAsync(Appointment appointment);

        Task<bool> DeleteAsync(string doctorPhone, DateTime date);

        Task<bool> SaveAsync(Appointment appointment);
    }
}