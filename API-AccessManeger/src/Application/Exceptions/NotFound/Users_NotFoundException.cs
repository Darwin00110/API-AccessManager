namespace API_AccessManeger.src.Application.Exceptions.NotFound
{
    public class Users_NotFoundException : Exception
    {
        public Users_NotFoundException() : base("Não existe registro de usuarios no banco de dados") { }
    }
}
