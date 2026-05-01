namespace API_AccessManeger.src.Application.Exceptions.EmptyExceptions
{
    public class Telephone_emptyException : Exception
    {
        public Telephone_emptyException() : base("Campo de telephone é obrigatorio. ") { }
    }
}
