namespace API_AccessManeger.src.Application.Exceptions.EmptyExceptions
{
    public class Password_emptyException : Exception
    {
        public Password_emptyException () : base("Campo de senha é obrigatorio. ") { }
    }
}
