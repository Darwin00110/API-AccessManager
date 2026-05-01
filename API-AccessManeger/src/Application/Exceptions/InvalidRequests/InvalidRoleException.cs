namespace API_AccessManeger.src.Application.Exceptions.InvalidRequests
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException() : base("O papel fornecido é inválido. Os papéis válidos são: ADMIN, USER.")
        {
        }
    }
}
