namespace API_AccessManeger.src.Application.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException() : base("Usuario ja existe. ") { }
    }
}
