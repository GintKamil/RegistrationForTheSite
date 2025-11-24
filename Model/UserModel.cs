using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RegistrationSite.Model
{
    public class UserModel : BaseModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserModel() { }
        public UserModel(string email, string password) 
        {
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Электронная почта - {Email}\nПароль - {Password}";
        }
    }
}
