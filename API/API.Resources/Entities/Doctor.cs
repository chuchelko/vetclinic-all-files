namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Doctor : Person
    {
        [Required]
        public string Position { get; set; }

        [Required]
        public int MinutesForAppointment { get; set; }

        public List<Disease> Diseases { get; set; } = new List<Disease>();

        public List<Appointment> Schedule { get; set; } = new List<Appointment>();

    }
}
