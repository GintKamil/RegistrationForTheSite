using System.ComponentModel.DataAnnotations;

namespace RegistrationSite.Model
{
    public class RegistrationModel : BaseModel
    {
        [Required(ErrorMessage = "Не указана электронная почта!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано возраст!")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст!")]
        public int Age { get; set; }

        [Required (ErrorMessage = "Не указан пароль!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Длина пароля должна быть от 5 до 50 символов!")]
        public string Password { get; set; }

        public RegistrationModel() { }
        public RegistrationModel(string name, int age, string email, string password)
        {
            Name = name;
            Age = age;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Имя - {Name}\nВозраст - {Age}\nЭлектронная почта - {Email}\nПароль - {Password}";
        }
    }
}
