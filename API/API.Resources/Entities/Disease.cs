namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Disease : IEntity<int>
    {
        public int Key => Id;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string? CodeInClassification { get; set; }

        [ForeignKey("Animal")]
        public string AnimalPassportChipNumber { get; set; }
        public Animal Animal { get; set; }

        [Required]
        public DateTime IllnessDate { get; set; }

        public DateTime? ConvalescenceDate { get; set; }

        [Required]
        public string AnimalCondition { get; set; }

        [Required]
        public string Treatment { get; set; }

        public string? AdditionalInformation { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorPassport { get; set; }
        public Doctor Doctor { get; set; }


    }
}
