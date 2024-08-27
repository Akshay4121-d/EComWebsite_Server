using System.ComponentModel.DataAnnotations;

namespace FirstStaticWeb.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobNumber { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AgreeTerms { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }

    }

    public class LoginModel
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
