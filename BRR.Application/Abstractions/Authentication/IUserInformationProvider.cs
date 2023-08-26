namespace BRR.Application.Abstractions.Authentication;

public interface IUserInformationProvider
{
    bool IsAuthenticated { get; }
    int UserId { get; }
}
