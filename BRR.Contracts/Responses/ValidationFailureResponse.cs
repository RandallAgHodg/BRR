namespace BRR.Contracts.Responses.Users;

public sealed record ValidationFailureResponse
{
    public ValidationFailureResponse(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; init; } = Enumerable.Empty<string>();
}
