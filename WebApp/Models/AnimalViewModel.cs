namespace WebApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AnimalViewModel
    {
        [Required]
        public string Passport { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Breed { get; set; }

        public string Color { get; set; }

        public string SpecificTraits { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
