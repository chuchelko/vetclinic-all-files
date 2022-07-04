namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProvidedService : IEntity<int>
    {
        public int Key => Id;

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        //если цена услуги поменяется, в истории услуг в базе данных останется прежняя цена
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorPassport { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Owner")]
        public string OwnerPassport { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("Animal")]
        public string AnimalPassportChipNumber { get; set; }
        public Animal Animal { get; set; }

    }
}
