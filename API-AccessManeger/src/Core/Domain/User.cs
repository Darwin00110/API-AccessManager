using System.Net.Mail;
using API_AccessManeger.src.Application.Exceptions.EmptyExceptions;
using API_AccessManeger.src.Application.Exceptions.InvalidFormatExceptions;

namespace API_AccessManeger;

public static class UserRoles
{
    public const string ADMIN = "ADMIN";
    public const string USER = "USER";
}

public class User
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telephone { get; set; }
    public string Role { get; set; }

    public void ValidateRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            throw new Exception("Role vazio, preencha corretamente (USER, ADMIN) ");
        }
        var verifyRole = role.ToUpper();
        if (verifyRole != UserRoles.USER && verifyRole != UserRoles.ADMIN)
        {
            throw new Exception("Role invalido. Use ADMIN ou USER");
        }
        Role = verifyRole;
    }

    public void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Name_emptyException();
        }
        bool nomeValido = name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        if (!nomeValido)
        {
            throw new Exception("O nome deve conter apenas letras e espaços.");
        }
    }
    public void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Email_emptyException();
        }
        try
        {
            var addr = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new Email_InvalidException();
        }
    }

    public void ValidateTelephone(string telephone)
    {
        if (string.IsNullOrWhiteSpace(telephone))
        {
            throw new Telephone_emptyException();
        }

        string cleanedTelephone = new string(
            telephone.Where(char.IsDigit).ToArray()
        );

        if (cleanedTelephone.Length < 10 || cleanedTelephone.Length > 11)
        {
            throw new Telephone_InvalidException();
        }
    }
    public void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new Password_emptyException();
        }
    }
    public void ValidateUser(string name, string email, string password, string telephone, string role)
    {
        ValidateRole(role);
        ValidatePassword(password);
        ValidateName(name);
        ValidateTelephone(telephone);
        Name = name;
        Email = email;
        Password = password;
        Telephone = telephone;
        Role = role.ToUpper();
    }
    public void ValidateUserLogin(string email, string password)
    {
        ValidateEmail(email);
        ValidatePassword(password);
    }
}
