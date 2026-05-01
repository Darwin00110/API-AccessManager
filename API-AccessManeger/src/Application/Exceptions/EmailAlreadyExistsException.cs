namespace API_AccessManeger.src.Application.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException() : base("Email ja cadastrado. ") { }
    }
}
