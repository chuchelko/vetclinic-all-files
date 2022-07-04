namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+ дегельминтизация сюда же
    public class AnimalProcedure : IEntity<int>
    {
        public int Key => AnimalProcedureId;

        [Key]
        public int AnimalProcedureId { get; set; }

        [ForeignKey("AnimalPassport")]
        public string AnimalPassportChipNumber { get; set; }

        public AnimalPassport AnimalPassport { get; set; }

        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public DateTime ProcedureTime { get; set; }

        [Required]
        public string DrugName { get; set; }

        [Required]
        public string DrugDose { get; set; }

        [Required]
        public string VeterinarianName { get; set; }

    }
}