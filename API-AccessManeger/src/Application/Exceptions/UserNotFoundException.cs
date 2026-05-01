namespace API_AccessManeger.src.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Usuario não encontrado. ") { }
    }
}
