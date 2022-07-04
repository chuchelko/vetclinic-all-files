namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    public class Animal : IEntity<string>
    {
        public string Key => AnimalPassportChipNumber;

        [Key]
        [ForeignKey("AnimalPassport")]
        public string AnimalPassportChipNumber { get; set; }
        public AnimalPassport AnimalPassport { get; set; }

        [ForeignKey("Owner")]
        public string OwnerPassport { get; set; }
        public Owner Owner { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Breed { get; set; }

        public string Color { get; set; }

        public string SpecificTraits { get; set; }

        public DateTime Birthday { get; set; }

        public List<Disease> Diseases { get; set; } = new List<Disease>();

    }
}
