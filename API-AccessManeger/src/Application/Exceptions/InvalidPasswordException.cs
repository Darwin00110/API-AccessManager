namespace API_AccessManeger.src.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException () : base("Senha invalida. ") { }
    }
}
