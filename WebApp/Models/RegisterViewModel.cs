namespace WebApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required, RegularExpression(@"^\d{4}\s\d{6}$",
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
        public string PhoneNumber { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(4, ErrorMessage = "At least 4 characters")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Только буквы английского алфавита")]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "Должен совпадать с паролем")]
        public string ConfirmPassword { get; set; }
    }
}
