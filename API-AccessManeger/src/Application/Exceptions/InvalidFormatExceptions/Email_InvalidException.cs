namespace API_AccessManeger.src.Application.Exceptions.InvalidFormatExceptions
{
    public class Email_InvalidException : Exception
    {
        public Email_InvalidException() : base("Email inválido. favor inserir o formato ( exemplo@gmail.com )") { }
    }
}
