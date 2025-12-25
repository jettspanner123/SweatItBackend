namespace SweatitBackEnd.Models.Base;

public class BadRequest(bool status, string message, List<string> errors)
{
    public bool Status = status;
    public string Message = message;
    public List<string> errors = errors;
}