namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Owner : Person
    {
        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public string Salt { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();

        public List<ProvidedService> Services { get; set; } = new List<ProvidedService>();

    }
}
