namespace API_AccessManeger.src.Application.Exceptions.InvalidFormatExceptions
{
    public class Telephone_InvalidException : Exception
    {
        public Telephone_InvalidException (): base("Telefone deve conter entre 10 e 11 dígitos.") {}
        public Telephone_InvalidException(string message) : base(message) { }
    }
}
