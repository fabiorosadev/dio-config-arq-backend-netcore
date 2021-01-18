using System.ComponentModel.DataAnnotations;

namespace Curso.Api.Models.Usuarios
{
    public class LoginViewModelinput
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
