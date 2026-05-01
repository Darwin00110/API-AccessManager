namespace API_AccessManeger.src.Application.Exceptions.EmptyExceptions
{
    public class Email_emptyException : Exception
    {
        public Email_emptyException() : base("Campo de Email OBRIGATORIO. ") { }
    }
}
