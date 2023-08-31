using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.User;

public sealed class OnlyAgentsCanApproveHousesProposalsException : ForbiddenException
{
    public OnlyAgentsCanApproveHousesProposalsException(string message) : base(message)
    {
    }
}
