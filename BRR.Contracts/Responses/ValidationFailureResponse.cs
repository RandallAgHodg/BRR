namespace BRR.Contracts.Responses.Users;

public sealed record ValidationFailureResponse
{
    public ValidationFailureResponse(IEnumerable<string> messages)
    {
        this.Errors = messages;
    }

    public IEnumerable<string> Errors { get; private set; } = Enumerable.Empty<string>();
}
