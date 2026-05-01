namespace API_AccessManeger;

public class InvalidRequestException : Exception
{
    public InvalidRequestException() : base("Requisição inválida, preencha os campos corretamente. ") { }
}