namespace API_AccessManeger.src.Application.Exceptions
{
    public class TelephoneAlreadyExistsException : Exception
    {
        public TelephoneAlreadyExistsException() : base("Telefone ja cadastrado. ") { }
    }
}
