namespace API.Resources.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person : IEntity<string>
    {
        public string Key => Passport;

        [Key, RegularExpression(@"^\d{4}\s\d{6}$",
            ErrorMessage = "Серия и номер паспорта должны указываться через пробел")]
        public string Passport { get; set; }

        [Required, RegularExpression(@"^([А-ЩЭ-Я][а-я]+-?)+$",
            ErrorMessage = "Имя должно начинаться с заглавной буквы, не иметь пробелов")]
        public string FirstName { get; set; }
        
        [Required, RegularExpression(@"^([А-ЩЭ-Я][а-я]+-?)+$",
            ErrorMessage = "Фамилия должна начинаться с заглавной буквы, не иметь пробелов")]
        public string LastName { get; set; }

        [RegularExpression(@"^([А-ЩЭ-Я][а-я]+-?)*$",
            ErrorMessage = "Отчество должно начинаться с заглавной буквы, не иметь пробелов")]
        public string Patronymic { get; set; }
        
        public DateTime Birthday { get; set; }

        [RegularExpression(@"^$|^\+7\s\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}$",
            ErrorMessage = "Допустимый формат номера: +7 (xxx) xxx-xx-xx")]
        public string Phone { get; set; }

    }
}