namespace SweatItBackEnd.Exceptions;

public class IdMismatchException: Exception {

    public IdMismatchException() { }
    public IdMismatchException(string message) : base(message) { }
    public IdMismatchException(string message, Exception innerException) : base(message, innerException) { }
}