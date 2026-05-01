namespace API_AccessManeger;

public class Email_NotFoundException : Exception
{
    public Email_NotFoundException() : base("Email não encontrado, ou incorreto. ")
    {
    }
}