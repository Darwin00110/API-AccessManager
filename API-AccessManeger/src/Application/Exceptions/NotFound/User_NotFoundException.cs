namespace API_AccessManeger.src.Application.Exceptions.NotFound
{
    public class User_NotFoundException : Exception
    {
        public User_NotFoundException() : base("O usuario passado não existe") { }
    }
}
