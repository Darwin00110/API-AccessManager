using System.ComponentModel.DataAnnotations;

namespace API_AccessManeger;

public class LoginUserRequest
{
    [Required(ErrorMessage = "Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "Formato de Email invalido.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatoria")]
    public string Password { get; set; }
}
