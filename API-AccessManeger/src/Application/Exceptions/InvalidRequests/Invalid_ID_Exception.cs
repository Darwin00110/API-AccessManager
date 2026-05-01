namespace API_AccessManeger.src.Application.Exceptions.InvalidRequests
{
    public class Invalid_ID_Exception : Exception
    {
        public Invalid_ID_Exception() : base("ID invalido, ou incorreto. ") { }
    }
}
