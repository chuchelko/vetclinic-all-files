namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Appointment : IEntity<int>
    {
        [Required]
        public DateTime AppointmentDate { get; set; }

        public string? ServiceName { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorPassport { get; set; }
        public Doctor Doctor { get; set; }


        [ForeignKey("Owner")]
        public string? OwnerPassport { get; set; }
        public Owner? Owner { get; set; }


    }
}
