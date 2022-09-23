using System.ComponentModel.DataAnnotations;

namespace ShopGame.Models
{
	public class LoginModel
	{
        [Required(ErrorMessage = "Не указан Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
