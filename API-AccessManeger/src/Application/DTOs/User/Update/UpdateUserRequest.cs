using System.ComponentModel.DataAnnotations;

namespace API_AccessManeger;

public class UpdateUserRequest
{
    [Required(ErrorMessage = "Nome é obrigatorio.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "Formato de Email invalido. ")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Senha é obrigatoria")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Role é obrigatorio ex: ('USER', 'ADMIN')")]
    public string Role { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatorio")]
    public string Telephone { get; set; }
}