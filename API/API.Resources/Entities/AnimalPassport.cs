namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AnimalPassport : IEntity<string>
    {
        public string Key => ChipNumber;

        [Key, RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Номер чипа должен быть числом без пробелов")]
        public string ChipNumber { get; set; }

        public Animal Animal { get; set; }

        [Required]
        public DateTime ChipInjection { get; set; }

        public List<AnimalProcedure> Procedures { get; set; } = new List<AnimalProcedure>();

    }
}