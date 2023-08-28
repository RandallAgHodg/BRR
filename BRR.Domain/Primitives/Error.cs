namespace BRR.Domain.Primitives;

public sealed class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    public string Code { get; }

    public string Message { get; }
}
