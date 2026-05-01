namespace API_AccessManeger.src.Application.DTOs.User.Create;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telephone { get; set; }
    public string Role { get; set; }
}