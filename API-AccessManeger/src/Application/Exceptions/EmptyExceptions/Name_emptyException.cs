namespace API_AccessManeger.src.Application.Exceptions.EmptyExceptions
{
    public class Name_emptyException : Exception
    {
        public Name_emptyException () : base("Campo de Nome OBRIGATORIO") { }
    }
}
