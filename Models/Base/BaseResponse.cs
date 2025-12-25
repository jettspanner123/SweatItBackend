namespace SweatitBackEnd.Models.Base;

public class BaseResponse(bool status, string message)
{
    public bool Status { get; set; } = status;
    public string Message { get; set; } = message;
}